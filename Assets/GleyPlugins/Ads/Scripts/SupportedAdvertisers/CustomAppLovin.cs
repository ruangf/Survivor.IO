namespace GleyMobileAds
{
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;
#if USE_APPLOVIN
    using System.Linq;
#endif

    public class CustomAppLovin : MonoBehaviour, ICustomAds
    {
#if USE_APPLOVIN
        const int reloadInterval = 20;
        const int maxRetryCount = 10;

        private UnityAction<bool, BannerPosition, BannerType> DisplayResult;
        private UnityAction OnInterstitialClosed;
        private UnityAction<string> OnInterstitialClosedWithAdvertiser;
        private UnityAction<bool> OnCompleteMethod;
        private UnityAction<bool, string> OnCompleteMethodWithAdvertiser;
        private UserConsent consent;
        private UserConsent ccpaConsent;
        private BannerPosition currentPosition;
        private BannerType bannerType;
        private string bannerId;
        private string interstitialId;
        private string rewardedVideoId;
        private int retryNumberInterstitial;
        private int retryNumberRewarded;
        private bool debug;
        private bool initialized;
        private bool bannerUsed;
        private bool rewardedVideoCompleted;
        private bool directedForChildren;


        /// <summary>
        /// Initializing AppLovin
        /// </summary>
        /// <param name="consent">user consent -> if true show personalized ads</param>
        /// <param name="platformSettings">contains all required settings for this publisher</param>
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
            debug = Advertisements.Instance.debug;
            this.consent = consent;
            this.ccpaConsent = ccpaConsent;
            if (initialized == false)
            {
                if (debug)
                {
                    MaxSdk.SetVerboseLogging(true);
                }

                //get settings
#if UNITY_ANDROID
                PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.Android);
#endif
#if UNITY_IOS
                PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.iOS);
#endif

                //preparing AppLovin SDK for initialization
                Debug.Log("APPID: " + settings.appId.id.ToString());
                directedForChildren = settings.directedForChildren;
                interstitialId = settings.idInterstitial.id;
                bannerId = settings.idBanner.id;
                rewardedVideoId = settings.idRewarded.id;
                MaxSdkCallbacks.OnSdkInitializedEvent += ApplovinInitialized;


                //Initialize the SDK
                MaxSdk.SetSdkKey(settings.appId.id.ToString());
                MaxSdk.InitializeSdk();

                if (debug)
                {
                    Debug.Log(this + " " + "Start Initialization");
                    ScreenWriter.Write(this + " " + "Start Initialization");
                    Debug.Log(this + " SDK key: " + settings.appId.id);
                    ScreenWriter.Write(this + " SDK key: " + settings.appId.id);
                }

                initialized = true;
            }
        }


        private void ApplovinInitialized(MaxSdk.SdkConfiguration obj)
        {
            if (debug)
            {
                Debug.Log(this + " Init Complete");
                ScreenWriter.Write(this + " Init Complete");
            }

            if (consent == UserConsent.Accept || consent == UserConsent.Unset)
            {
                MaxSdk.SetHasUserConsent(true);
            }
            else
            {
                MaxSdk.SetHasUserConsent(false);
            }

            if (directedForChildren == true)
            {
                MaxSdk.SetIsAgeRestrictedUser(true);
            }
            else
            {
                MaxSdk.SetIsAgeRestrictedUser(false);
            }

            if (ccpaConsent == UserConsent.Accept || ccpaConsent == UserConsent.Unset)
            {
                MaxSdk.SetDoNotSell(false);
            }
            else
            {
                MaxSdk.SetDoNotSell(true);
            }

            if (!string.IsNullOrEmpty(bannerId))
            {
                MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
                MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdFailedEvent;
                MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
                MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
            }

            if (!string.IsNullOrEmpty(interstitialId))
            {
                // Attach callbacks
                MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
                MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialFailedEvent;
                MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += InterstitialFailedToDisplayEvent;
                MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;
                MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;

                LoadInterstitial();
            }

            if (!string.IsNullOrEmpty(rewardedVideoId))
            {
                // Attach callbacks
                MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
                MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdFailedEvent;
                MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
                MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
                MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
                MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdDismissedEvent;
                MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
                MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;

                //start loading ads
                LoadRewardedVideo();
            }
        }


        /// <summary>
        /// Updates consent at runtime
        /// </summary>
        /// <param name="consent">the new consent</param>
        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
            if (consent == UserConsent.Accept || consent == UserConsent.Unset)
            {
                MaxSdk.SetHasUserConsent(true);
            }
            else
            {
                MaxSdk.SetHasUserConsent(false);
            }

            if (ccpaConsent == UserConsent.Accept || ccpaConsent == UserConsent.Unset)
            {
                MaxSdk.SetDoNotSell(false);
            }
            else
            {
                MaxSdk.SetDoNotSell(true);
            }
        }

        #region Banner
        /// <summary>
        /// Check if AppLovin banner is available
        /// </summary>
        /// <returns>always returns true, AppLovin does not have such a method for banners</returns>
        public bool IsBannerAvailable()
        {
            return true;
        }


        /// <summary>
        /// Used for mediation purpose
        /// </summary>
        public void ResetBannerUsage()
        {
            bannerUsed = false;
        }


        /// <summary>
        /// Used for mediation purpose
        /// </summary>
        /// <returns>true if current banner failed to load</returns>
        public bool BannerAlreadyUsed()
        {
            return bannerUsed;
        }


        /// <summary>
        /// Show AppLovin banner
        /// </summary>
        /// <param name="position">can be TOP of BOTTOM</param>
        /// <param name="bannerType">it is not used in AppLovin, this param is used just in Admob implementation</param>
        public void ShowBanner(BannerPosition position, BannerType bannerType, UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {
            bannerUsed = true;

            this.bannerType = bannerType;
            this.DisplayResult = DisplayResult;

            LoadBanner(position, bannerType);
            MaxSdk.ShowBanner(bannerId);

            currentPosition = position;
        }


        private void LoadBanner(BannerPosition position, BannerType bannerType)
        {
            MaxSdk.DestroyBanner(bannerId);
            if (position == BannerPosition.TOP)
            {
                MaxSdk.CreateBanner(bannerId, MaxSdkBase.BannerPosition.TopCenter);
            }
            else
            {
                MaxSdk.CreateBanner(bannerId, MaxSdkBase.BannerPosition.BottomCenter);
            }
            // Set background or background color for banners to be fully functional.
            MaxSdk.SetBannerBackgroundColor(bannerId, Color.black);
        }


        /// <summary>
        /// Hides AppLovin banner
        /// </summary>
        public void HideBanner()
        {
            MaxSdk.HideBanner(bannerId);
        }


        void BannerShown()
        {
            if (debug)
            {
                Debug.Log(this + " banner ad shown");
                ScreenWriter.Write(this + " banner ad shown");
            }

            if (DisplayResult != null)
            {
                DisplayResult(true, currentPosition, bannerType);
                DisplayResult = null;
            }
        }


        private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " banner ad loaded");
                ScreenWriter.Write(this + " banner ad loaded");
            }
            BannerShown();
        }


        private void OnBannerAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            if (debug)
            {
                Debug.Log(this + " banner ad failed to load " + errorInfo.Code + " " + errorInfo.Message);
                ScreenWriter.Write(this + " banner ad failed to load " + errorInfo.Code + " " + errorInfo.Message);
            }

            if (DisplayResult != null)
            {
                DisplayResult(false, currentPosition, bannerType);
                DisplayResult = null;
            }
        }


        private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " banner ad clicked");
                ScreenWriter.Write(this + " banner ad clicked");
            }
        }


        private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " banner ad revenue paid");
                ScreenWriter.Write(this + " banner ad revenue paid");
            }
        }
        #endregion

        #region Interstitial
        /// <summary>
        /// Check if AppLovin interstitial is available
        /// </summary>
        /// <returns>true if an interstitial is available</returns>
        public bool IsInterstitialAvailable()
        {
            return MaxSdk.IsInterstitialReady(interstitialId);
        }


        /// <summary>
        /// Preload an interstitial ad before showing
        /// if it fails for maxRetryCount times do not try anymore
        /// </summary>
        void LoadInterstitial()
        {
            if (retryNumberInterstitial < maxRetryCount)
            {
                if (debug)
                {
                    ScreenWriter.Write(this + " Load Interstitial");
                }
                retryNumberInterstitial++;
                MaxSdk.LoadInterstitial(interstitialId);
            }
        }


        /// <summary>
        /// Show AppLovin interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial</param>
        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosed = InterstitialClosed;
                MaxSdk.ShowInterstitial(interstitialId);
            }
        }


        /// <summary>
        /// Show AppLovin interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial also containing the provider of the closed interstitial</param>
        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosedWithAdvertiser = InterstitialClosed;
                MaxSdk.ShowInterstitial(interstitialId);
            }
        }


        private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " interstitial ad was loaded");
                ScreenWriter.Write(this + " interstitial ad was loaded");
            }
            retryNumberInterstitial = 0;
        }


        private void OnInterstitialFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            if (debug)
            {
                Debug.Log(this + " interstitial ad failed to load: " + errorInfo.Code);
                ScreenWriter.Write(this + " interstitial ad failed to load " + errorInfo.Code);
                Debug.Log(this + " reloading " + retryNumberInterstitial + " in " + reloadInterval + " sec");
                ScreenWriter.Write(this + " reloading " + retryNumberInterstitial + " in " + reloadInterval + " sec");
            }
            //wait and load another
            Invoke("LoadInterstitial", reloadInterval);
        }


        private void InterstitialFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " interstitial ad failed to display: " + errorInfo.Code);
                ScreenWriter.Write(this + " interstitial ad failed to display " + errorInfo.Code);
            }
            LoadInterstitial();
        }


        private void OnInterstitialDismissedEvent(string arg1, MaxSdkBase.AdInfo arg2)
        {
            if (debug)
            {
                Debug.Log(this + " interstitial ad was closed");
                ScreenWriter.Write(this + " interstitial ad was closed");
            }

            //trigger closed callback
            if (OnInterstitialClosed != null)
            {
                OnInterstitialClosed();
                OnInterstitialClosed = null;
            }
            if (OnInterstitialClosedWithAdvertiser != null)
            {
                OnInterstitialClosedWithAdvertiser(SupportedAdvertisers.AppLovin.ToString());
                OnInterstitialClosedWithAdvertiser = null;
            }

            //load another ad
            LoadInterstitial();
        }


        private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                // Ad revenue
                double revenue = adInfo.Revenue;

                // Miscellaneous data
                string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
                string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
                string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
                string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

                Debug.Log(this + " revenue " + revenue + " countryCode " + countryCode + " networkName " + networkName + " adUnitIdentifier " + adUnitIdentifier + " placement " + placement);
                ScreenWriter.Write(this + " revenue " + revenue + " countryCode " + countryCode + " networkName " + networkName + " adUnitIdentifier " + adUnitIdentifier + " placement " + placement);
            }
        }
        #endregion

        #region RewardedVideo

        /// <summary>
        /// Check if AppLovin rewarded video is available
        /// </summary>
        /// <returns>true if a rewarded video is available</returns>
        public bool IsRewardVideoAvailable()
        {
            return MaxSdk.IsRewardedAdReady(rewardedVideoId);
        }


        /// <summary>
        /// preload a rewarded video ad before showing
        /// if it fails for maxRetryCount times do not try anymore
        /// </summary>
        void LoadRewardedVideo()
        {
            if (retryNumberRewarded < maxRetryCount)
            {
                if (debug)
                {
                    ScreenWriter.Write(this + " Load Rewarded Video");
                }
                retryNumberRewarded++;
                MaxSdk.LoadRewardedAd(rewardedVideoId);
            }
        }


        /// <summary>
        /// Show AppLovin rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true, video was not skipped</param>
        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethod = CompleteMethod;
                rewardedVideoCompleted = false;
                MaxSdk.ShowRewardedAd(rewardedVideoId);
            }
        }


        /// <summary>
        /// Show AppLovin rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true, video was not skipped, also contains the advertiser name of the closed ad</param>
        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethodWithAdvertiser = CompleteMethod;
                rewardedVideoCompleted = false;
                MaxSdk.ShowRewardedAd(rewardedVideoId);
            }
        }


        private void OnRewardedAdLoadedEvent(string arg1, MaxSdkBase.AdInfo arg2)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video was successfully loaded");
                ScreenWriter.Write(this + " rewarded video was successfully loaded");
            }
            retryNumberRewarded = 0;
        }


        private void OnRewardedAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video failed to load " + errorInfo.Code + " " + errorInfo.Message);
                ScreenWriter.Write(this + " rewarded video failed to load " + errorInfo.Code + " " + errorInfo.Message);
                Debug.Log(this + " reloading " + retryNumberRewarded + " in " + reloadInterval + " sec");
                ScreenWriter.Write(this + " reloading " + retryNumberRewarded + " in " + reloadInterval + " sec");
            }
            //wait and load another
            Invoke("LoadRewardedVideo", reloadInterval);
        }


        private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video failed to display " + errorInfo.Code + " " + errorInfo.Message);
                ScreenWriter.Write(this + " rewarded video failed to display " + errorInfo.Code + " " + errorInfo.Message);
            }
            LoadRewardedVideo();
        }


        private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video displayed");
                ScreenWriter.Write(this + " rewarded video displayed");
            }
        }


        private void OnRewardedAdClickedEvent(string arg1, MaxSdkBase.AdInfo arg2)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video clicked");
                ScreenWriter.Write(this + " rewarded video clicked");
            }
        }


        private void OnRewardedAdDismissedEvent(string arg1, MaxSdkBase.AdInfo arg2)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video was closed");
                ScreenWriter.Write(this + " rewarded video was closed");
            }

            //trigger rewarded video completed callback method
            if (OnCompleteMethod != null)
            {
                OnCompleteMethod(rewardedVideoCompleted);
                OnCompleteMethod = null;
            }
            if (OnCompleteMethodWithAdvertiser != null)
            {
                OnCompleteMethodWithAdvertiser(rewardedVideoCompleted, SupportedAdvertisers.AppLovin.ToString());
                OnCompleteMethodWithAdvertiser = null;
            }

            //load another rewarded video
            LoadRewardedVideo();
        }


        private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                Debug.Log(this + " rewarded video was completed");
                ScreenWriter.Write(this + " rewarded video was completed");
            }
            rewardedVideoCompleted = true;
        }


        private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (debug)
            {
                // Ad revenue
                double revenue = adInfo.Revenue;

                // Miscellaneous data
                string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
                string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
                string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
                string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

                Debug.Log(this + " revenue " + revenue + " countryCode " + countryCode + " networkName " + networkName + " adUnitIdentifier " + adUnitIdentifier + " placement " + placement);
                ScreenWriter.Write(this + " revenue " + revenue + " countryCode " + countryCode + " networkName " + networkName + " adUnitIdentifier " + adUnitIdentifier + " placement " + placement);
            }
        }
        #endregion

        private void OnApplicationFocus(bool focus)
        {
            ScreenWriter.Write(maxRetryCount + " " + retryNumberInterstitial);
            if (focus == true)
            {
                if (IsInterstitialAvailable() == false)
                {
                    if (retryNumberInterstitial == maxRetryCount)
                    {
                        retryNumberInterstitial--;
                        LoadInterstitial();
                    }
                }

                if (IsRewardVideoAvailable() == false)
                {
                    if (retryNumberRewarded == maxRetryCount)
                    {
                        retryNumberRewarded--;
                        LoadRewardedVideo();
                    }
                }
            }
        }
#else
        //dummy interface implementation, used when AppLovin is not enabled
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {

        }


        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {

        }


        public bool IsBannerAvailable()
        {
            return false;
        }


        public void ShowBanner(BannerPosition position, BannerType type, UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {

        }


        public void HideBanner()
        {

        }


        public void ResetBannerUsage()
        {

        }


        public bool BannerAlreadyUsed()
        {
            return false;
        }


        public bool IsInterstitialAvailable()
        {
            return false;
        }


        public void ShowInterstitial(UnityAction InterstitialClosed)
        {

        }


        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {

        }


        public bool IsRewardVideoAvailable()
        {
            return false;
        }


        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {

        }


        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {

        }
#endif
    }
}
