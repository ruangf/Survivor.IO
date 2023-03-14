namespace GleyMobileAds
{
    using UnityEngine.Events;
    using UnityEngine;
#if USE_UNITYADS
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.Advertisements;
#endif

#if USE_UNITYADS
    public class CustomUnityAds : MonoBehaviour, ICustomAds, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        const int reloadInterval = 20;
        const int maxRetryCount = 10;

        private UnityAction<bool> OnCompleteMethod;
        private UnityAction<bool, string> OnCompleteMethodWithAdvertiser;
        private UnityAction OnInterstitialClosed;
        private UnityAction<string> OnInterstitialClosedWithAdvertiser;

        private string unityAdsId;
        private string bannerPlacement;
        private string videoAdPlacement;
        private string rewardedVideoAdPlacement;
        private bool debug;
        private bool bannerUsed;
        private bool interstitialAvailable;
        private bool rewardedAvailable;
        private global::BannerPosition position;
        private BannerType bannerType;
        private UnityAction<bool, global::BannerPosition, BannerType> DisplayResult;

        private int retryNumberInterstitial;
        private int retryNumberRewarded;



        /// <summary>
        /// Initializing Unity Ads
        /// </summary>
        /// <param name="consent">user consent -> if true show personalized ads</param>
        /// <param name="platformSettings">contains all required settings for this publisher</param>
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
            debug = Advertisements.Instance.debug;

            //get settings
#if UNITY_ANDROID
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.Android);
#endif
#if UNITY_IOS
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.iOS);
#endif
            //apply settings
            unityAdsId = settings.appId.id;
            bannerPlacement = settings.idBanner.id;
            videoAdPlacement = settings.idInterstitial.id;
            rewardedVideoAdPlacement = settings.idRewarded.id;

            //verify settings
            if (debug)
            {
                Debug.Log(this + " Initialization Started");
                ScreenWriter.Write(this + " Initialization Started");
                Debug.Log(this + " App ID: " + unityAdsId);
                ScreenWriter.Write(this + " App ID: " + unityAdsId);
                Debug.Log(this + " Banner placement ID: " + bannerPlacement);
                ScreenWriter.Write(this + " Banner Placement ID: " + bannerPlacement);
                Debug.Log(this + " Interstitial Placement ID: " + videoAdPlacement);
                ScreenWriter.Write(this + " Interstitial Placement ID: " + videoAdPlacement);
                Debug.Log(this + " Rewarded Video Placement ID: " + rewardedVideoAdPlacement);
                ScreenWriter.Write(this + " Rewarded Video Placement ID: " + rewardedVideoAdPlacement);
            }

            //preparing Unity Ads SDK for initialization
            if (consent != UserConsent.Unset)
            {
                MetaData gdprMetaData = new MetaData("gdpr");
                if (consent == UserConsent.Accept)
                {
                    gdprMetaData.Set("consent", "true");
                }
                else
                {
                    gdprMetaData.Set("consent", "false");
                }
                Advertisement.SetMetaData(gdprMetaData);
            }

            if (ccpaConsent != UserConsent.Unset)
            {
                MetaData privacyMetaData = new MetaData("privacy");
                if (consent == UserConsent.Accept)
                {
                    privacyMetaData.Set("consent", "true");
                }
                else
                {
                    privacyMetaData.Set("consent", "false");
                }
                Advertisement.SetMetaData(privacyMetaData);
            }

            // Advertisement.Initialize(unityAdsId, false, true, this);
            Advertisement.Initialize(unityAdsId, false, this);
        }


        /// <summary>
        /// Updates consent at runtime
        /// </summary>
        /// <param name="consent">the new consent</param>
        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
            if (consent != UserConsent.Unset)
            {
                MetaData gdprMetaData = new MetaData("gdpr");
                if (consent == UserConsent.Accept)
                {
                    gdprMetaData.Set("consent", "true");
                }
                else
                {
                    gdprMetaData.Set("consent", "false");
                }
                Advertisement.SetMetaData(gdprMetaData);
            }

            if (ccpaConsent != UserConsent.Unset)
            {
                MetaData privacyMetaData = new MetaData("privacy");
                if (consent == UserConsent.Accept)
                {
                    privacyMetaData.Set("consent", "true");
                }
                else
                {
                    privacyMetaData.Set("consent", "false");
                }
                Advertisement.SetMetaData(privacyMetaData);
            }
            if (debug)
            {
                Debug.Log(this + " Update consent to " + consent);
                ScreenWriter.Write(this + " Update consent to " + consent);
            }
        }


        public void OnInitializationComplete()
        {
            if (debug)
            {
                Debug.Log(this + " initialization complete.");
                ScreenWriter.Write(this + " initialization complete.");
            }
            LoadInterstitialAd();
            LoadRewardedVideo();
        }


        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            if (debug)
            {
                Debug.Log($"Unity Ads Initialization Failed: {error} - {message}");
                ScreenWriter.Write($"Unity Ads Initialization Failed: {error} - {message}");
            }
        }


        #region Interstitial
        /// <summary>
        /// Check if Unity Ads interstitial is available
        /// </summary>
        /// <returns>true if an interstitial is available</returns>
        public bool IsInterstitialAvailable()
        {
            return interstitialAvailable;
        }


        public void LoadInterstitialAd()
        {
            interstitialAvailable = false;
            if (debug)
            {
                Debug.Log(this + " Loading Interstitial Ad: " + videoAdPlacement);
                ScreenWriter.Write(this + " Loading Interstitial Ad: " + videoAdPlacement);
            }
            Advertisement.Load(videoAdPlacement, this);
        }


        /// <summary>
        /// Show Unity Ads interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial</param>
        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosed = InterstitialClosed;
                Advertisement.Show(videoAdPlacement, this);
            }
        }


        /// <summary>
        /// Show Unity Ads interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial</param>
        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosedWithAdvertiser = InterstitialClosed;
                Advertisement.Show(videoAdPlacement, this);
            }
        }
        #endregion

        #region RewardedVideo
        /// <summary>
        /// Check if Unity Ads rewarded video is available
        /// </summary>
        /// <returns>true if a rewarded video is available</returns>
        public bool IsRewardVideoAvailable()
        {
            return rewardedAvailable;
        }


        private void LoadRewardedVideo()
        {
            rewardedAvailable = false;
            if (debug)
            {
                Debug.Log(this + " Loading Rewarded Video Ad: " + rewardedVideoAdPlacement);
                ScreenWriter.Write(this + " Loading Rewarded Video Ad: " + rewardedVideoAdPlacement);
            }
            Advertisement.Load(rewardedVideoAdPlacement, this);
        }


        /// <summary>
        /// Show Unity Ads rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true, video was not skipped</param>
        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethod = CompleteMethod;
                Advertisement.Show(rewardedVideoAdPlacement, this);
            }
        }


        /// <summary>
        /// Show Unity Ads rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true, video was not skipped</param>
        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethodWithAdvertiser = CompleteMethod;
                Advertisement.Show(rewardedVideoAdPlacement, this);
            }
        }
        #endregion

        #region Events
        public void OnUnityAdsAdLoaded(string placementId)
        {
            if (placementId == videoAdPlacement)
            {
                interstitialAvailable = true;
                if (debug)
                {
                    Debug.Log(this + " Interstitial Ad Loaded: " + placementId);
                    ScreenWriter.Write(this + " Interstitial Ad Loaded: " + placementId);
                }
            }

            if (placementId == rewardedVideoAdPlacement)
            {
                rewardedAvailable = true;
                if (debug)
                {
                    Debug.Log(this + " Rewarded Video Ad Loaded: " + placementId);
                    ScreenWriter.Write(this + " Rewarded Video Ad Loaded: " + placementId);
                }
            }
        }


        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            if (debug)
            {
                Debug.Log(this + $"Error loading Ad Unit: {placementId} - {error.ToString()} - {message}");
                ScreenWriter.Write(this + $"Error loading Ad Unit: {placementId} - {error.ToString()} - {message}");
            }
            if (placementId == videoAdPlacement)
            {
                retryNumberInterstitial++;
                if (retryNumberInterstitial < maxRetryCount)
                {
                    Invoke("LoadInterstitialAd", reloadInterval);
                }
            }
            if (placementId == rewardedVideoAdPlacement)
            {
                retryNumberRewarded++;
                if (retryNumberRewarded < maxRetryCount)
                {
                    Invoke("LoadRewardedVideo", reloadInterval);
                }
            }
        }


        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            if (debug)
            {
                Debug.Log(this + $"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
                ScreenWriter.Write(this + $"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
            }
            if (placementId == videoAdPlacement)
            {
                LoadInterstitialAd();
            }

            if (placementId == rewardedVideoAdPlacement)
            {
                LoadRewardedVideo();
            }
        }


        public void OnUnityAdsShowStart(string placementId)
        {
            if (debug)
            {
                Debug.Log(this + " Ad Shown: " + placementId);
                ScreenWriter.Write(this + " Ad Shown: " + placementId);
            }

            if (placementId == videoAdPlacement)
            {
                retryNumberInterstitial = 0;
            }

            if (placementId == rewardedVideoAdPlacement)
            {
                retryNumberRewarded = 0;
            }
        }


        public void OnUnityAdsShowClick(string placementId)
        {
            if (debug)
            {
                Debug.Log(this + " Ad Clicked: " + placementId);
                ScreenWriter.Write(this + " Ad Clicked: " + placementId);
            }
        }


        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            ScreenWriter.Write("OnUnityAdsShowComplete " + placementId);
            if (placementId == videoAdPlacement)
            {
                if (debug)
                {
                    Debug.Log(this + "Interstitial result: " + showCompletionState);
                    ScreenWriter.Write(this + "Interstitial result: " + showCompletionState);
                }

                if (OnInterstitialClosed != null)
                {
                    OnInterstitialClosed();
                    OnInterstitialClosed = null;
                }

                if (OnInterstitialClosedWithAdvertiser != null)
                {
                    OnInterstitialClosedWithAdvertiser(SupportedAdvertisers.Unity.ToString());
                    OnInterstitialClosedWithAdvertiser = null;
                }
                LoadInterstitialAd();
            }

            if (placementId == rewardedVideoAdPlacement)
            {
                if (debug)
                {
                    Debug.Log(this + "Complete method result: " + showCompletionState);
                    ScreenWriter.Write(this + "Complete method result: " + showCompletionState);
                }
                if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
                {
                    if (OnCompleteMethod != null)
                    {
                        OnCompleteMethod(true);
                        OnCompleteMethod = null;
                    }
                    if (OnCompleteMethodWithAdvertiser != null)
                    {
                        OnCompleteMethodWithAdvertiser(true, SupportedAdvertisers.Unity.ToString());
                        OnCompleteMethodWithAdvertiser = null;
                    }
                }
                else
                {
                    if (OnCompleteMethod != null)
                    {
                        OnCompleteMethod(false);
                        OnCompleteMethod = null;
                    }
                    if (OnCompleteMethodWithAdvertiser != null)
                    {
                        OnCompleteMethodWithAdvertiser(false, SupportedAdvertisers.Unity.ToString());
                        OnCompleteMethodWithAdvertiser = null;
                    }
                }
                LoadRewardedVideo();
            }
        }
        #endregion

        #region Banner
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


        public void ShowBanner(global::BannerPosition position, BannerType bannerType, UnityAction<bool, global::BannerPosition, BannerType> DisplayResult)
        {
            if (IsBannerAvailable())
            {
                bannerUsed = true;

                this.position = position;
                this.bannerType = bannerType;
                this.DisplayResult = DisplayResult;

                if (position == global::BannerPosition.BOTTOM)
                {
                    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                }
                else
                {
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                }

                BannerLoadOptions options = new BannerLoadOptions
                {
                    errorCallback = BannerLoadFailed,
                    loadCallback = BannerLoadSuccess
                };
                if (debug)
                {
                    Debug.Log(this + "Start Loading Placement:" + bannerPlacement);
                    ScreenWriter.Write(this + "Start Loading Placement:" + bannerPlacement);
                }

                Advertisement.Banner.Load(bannerPlacement, options);
            }
        }

        private void BannerLoadSuccess()
        {
            if (debug)
            {
                Debug.Log(this + "Banner Load Success");
                ScreenWriter.Write(this + " Banner Load Success");
            }

            BannerOptions options = new BannerOptions
            {
                showCallback = BanerDisplayed,
                hideCallback = BannerHidded
            };
            Advertisement.Banner.Show(bannerPlacement, options);
        }

        private void BannerLoadFailed(string message)
        {
            if (debug)
            {
                Debug.Log(this + "Banner Load Failed " + message);
                ScreenWriter.Write(this + " Banner Load Failed " + message);
            }
            if (DisplayResult != null)
            {
                DisplayResult(false, position, bannerType);
                DisplayResult = null;
            }
            HideBanner();
        }
        private void BanerDisplayed()
        {
            if (debug)
            {
                Debug.Log(this + "Banner Displayed");
                ScreenWriter.Write(this + "Banner Displayed");
            }
            if (DisplayResult != null)
            {
                DisplayResult(true, position, bannerType);
                DisplayResult = null;
            }
        }


        private void BannerHidded()
        {
            if (debug)
            {
                Debug.Log(this + "Banner Hidden");
                ScreenWriter.Write(this + "Banner Hidden");
            }
        }

        public void HideBanner()
        {
            if (debug)
            {
                Debug.Log(this + "Hide Banner");
                ScreenWriter.Write(this + "Hide Banner");
            }
            Advertisement.Banner.Hide(true);
        }
        #endregion
#else
        //dummy interface implementation
        public class CustomUnityAds : MonoBehaviour, ICustomAds
    {
        public void HideBanner()
        {

        }

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, System.Collections.Generic.List<PlatformSettings> platformSettings)
        {

        }

        public bool IsBannerAvailable()
        {
            return false;
        }

        public bool IsInterstitialAvailable()
        {
            return false;
        }

        public bool IsRewardVideoAvailable()
        {
            return false;
        }

        public void ShowBanner(BannerPosition position, BannerType type, UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {

        }

        public void ResetBannerUsage()
        {

        }

        public bool BannerAlreadyUsed()
        {
            return false;
        }

        public void ShowInterstitial(UnityAction InterstitialClosed = null)
        {

        }

        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {

        }

        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {

        }

        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {

        }

        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {

        }
#endif
    }
}

