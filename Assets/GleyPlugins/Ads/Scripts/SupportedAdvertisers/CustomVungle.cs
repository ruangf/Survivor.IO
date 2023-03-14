namespace GleyMobileAds
{
    using UnityEngine.Events;
    using System.Collections.Generic;
    using UnityEngine;
#if USE_VUNGLE
    using System.Linq;
    using System.Collections;
#endif

    public class CustomVungle : MonoBehaviour, ICustomAds
    {
#if USE_VUNGLE
        private UnityAction<bool> OnCompleteMethod;
        private UnityAction<bool, string> OnCompleteMethodWithAdvertiser;
        private UnityAction OnInterstitialClosed;
        private UnityAction<string> OnInterstitialClosedWithAdvertiser;
        private UnityAction<bool, BannerPosition, BannerType> DisplayResult;
        private UserConsent consent;
        private BannerPosition currentPosition;
        private BannerType bannerType;
        private string appID = "";
        private string rewardedPlacementId = "";
        private string interstitialPlacementID = "";
        private string bannerPlacementID = "";
        private bool debug;
        private bool initComplete;
        private bool bannerUsed;


        /// <summary>
        /// Initializing Vungle
        /// </summary>
        /// <param name="consent">user consent -> if true show personalized ads</param>
        /// <param name="platformSettings">contains all required settings for this publisher</param>
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
            this.consent = consent;
            debug = Advertisements.Instance.debug;

            //get settings
#if UNITY_ANDROID
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.Android);
#elif UNITY_IOS
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.iOS);
#else
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.Windows);
#endif
            //apply settings
            appID = settings.appId.id;
            rewardedPlacementId = settings.idRewarded.id;
            interstitialPlacementID = settings.idInterstitial.id;
            bannerPlacementID = settings.idBanner.id;

            //verify settings
            if (debug)
            {
                Debug.Log(this + " Initialization Started");
                ScreenWriter.Write(this + " Initialization Started");
                Debug.Log(this + " App ID: " + appID);
                ScreenWriter.Write(this + " App ID: " + appID);
                Debug.Log(this + " Interstitial Placement ID: " + interstitialPlacementID);
                ScreenWriter.Write(this + " Interstitial Placement ID: " + interstitialPlacementID);
                Debug.Log(this + " Rewarded Video Placement ID: " + rewardedPlacementId);
                ScreenWriter.Write(this + " Rewarded Video Placement ID: " + rewardedPlacementId);
            }

            //preparing Vungle SDK for initialization
            Dictionary<string, bool> placements = new Dictionary<string, bool>
            {
                { rewardedPlacementId, false },
                { interstitialPlacementID, false }
            };

            string[] array = new string[placements.Keys.Count];
            placements.Keys.CopyTo(array, 0);            
            Vungle.onInitializeEvent += InitComplete;
            Vungle.onAdStartedEvent += AdStarted;
            Vungle.onLogEvent += VungleLog;
            Vungle.onAdEndEvent = OnAdEnd;
            Vungle.onAdRewardedEvent += OnAdRewarded;
            Vungle.onErrorEvent += OnErrorEvent;
            Vungle.onPlacementPreparedEvent += OnPlacementPreparedEvent;
            Vungle.adPlayableEvent += AdPlayableEvent;
            Vungle.init(appID);
        }

        /// <summary>
        /// Updates consent at runtime
        /// </summary>
        /// <param name="consent">the new consent</param>
        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
            switch (consent)
            {
                case UserConsent.Unset:
                    Vungle.updateConsentStatus(Vungle.Consent.Undefined);
                    break;
                case UserConsent.Accept:
                    Vungle.updateConsentStatus(Vungle.Consent.Accepted);
                    break;
                case UserConsent.Deny:
                    Vungle.updateConsentStatus(Vungle.Consent.Denied);
                    break;
            }

            switch (ccpaConsent)
            {
                case UserConsent.Unset:
                    Vungle.updateCCPAStatus(Vungle.Consent.Undefined);
                    break;
                case UserConsent.Accept:
                    Vungle.updateCCPAStatus(Vungle.Consent.Accepted);
                    break;
                case UserConsent.Deny:
                    Vungle.updateCCPAStatus(Vungle.Consent.Denied);
                    break;
            }

            Debug.Log(this + " Update consent to " + consent);
            ScreenWriter.Write(this + " Update consent to " + consent);
        }

        #region Banner
        public void ShowBanner(BannerPosition position, BannerType bannerType, UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {
            currentPosition = position;
            this.bannerType = bannerType;
            this.DisplayResult = DisplayResult;
            bannerUsed = true;
            if (position == BannerPosition.TOP)
            {
                Vungle.loadBanner(bannerPlacementID, Vungle.VungleBannerSize.VungleAdSizeBanner, Vungle.VungleBannerPosition.TopCenter);
            }
            else
            {
                Vungle.loadBanner(bannerPlacementID, Vungle.VungleBannerSize.VungleAdSizeBanner, Vungle.VungleBannerPosition.BottomCenter);
            }

            StartCoroutine(WaitForBanner());
        }

        IEnumerator WaitForBanner()
        {
            while (Vungle.isAdvertAvailable(bannerPlacementID, Vungle.VungleBannerSize.VungleAdSizeBanner) == false)
            {
                yield return new WaitForSeconds(0.5f);
            }
            Vungle.showBanner(bannerPlacementID);
            BannerShown();
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

        public void ResetBannerUsage()
        {
            bannerUsed = false;
        }


        public bool BannerAlreadyUsed()
        {
            return bannerUsed;
        }


        public bool IsBannerAvailable()
        {
            return true;
        }


        public void HideBanner()
        {
            StopAllCoroutines();
            Vungle.closeBanner(bannerPlacementID);
        }
        #endregion

        #region Interstitial
        /// <summary>
        /// Check if Vungle interstitial is available
        /// </summary>
        /// <returns>true if an interstitial is available</returns>
        public bool IsInterstitialAvailable()
        {
            if (!initComplete)
                return false;
            return Vungle.isAdvertAvailable(interstitialPlacementID);
        }


        /// <summary>
        /// Show Vungle interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial</param>
        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosed = InterstitialClosed;
                Vungle.playAd(interstitialPlacementID);
            }
        }


        /// <summary>
        /// Show Vungle interstitial
        /// </summary>
        /// <param name="InterstitialClosed">callback called when user closes interstitial</param>
        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
            if (IsInterstitialAvailable())
            {
                OnInterstitialClosedWithAdvertiser = InterstitialClosed;
                Vungle.playAd(interstitialPlacementID);
            }
        }
        #endregion

        #region RewardedVideo
        /// <summary>
        /// Check if Vungle rewarded video is available
        /// </summary>
        /// <returns>true if a rewarded video is available</returns>
        public bool IsRewardVideoAvailable()
        {
            if (!initComplete)
                return false;
            return Vungle.isAdvertAvailable(rewardedPlacementId);
        }


        /// <summary>
        /// Show Vungle rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true video was not skipped</param>
        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethod = CompleteMethod;
                Vungle.playAd(rewardedPlacementId);
            }
        }


        /// <summary>
        /// Show Vungle rewarded video
        /// </summary>
        /// <param name="CompleteMethod">callback called when user closes the rewarded video -> if true video was not skipped</param>
        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
            if (IsRewardVideoAvailable())
            {
                OnCompleteMethodWithAdvertiser = CompleteMethod;
                Vungle.playAd(rewardedPlacementId);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Vungle specific event triggered after initialization is done
        /// </summary>
        private void InitComplete()
        {

            initComplete = true;
            Vungle.onInitializeEvent -= InitComplete;

            switch (consent)
            {
                case UserConsent.Unset:
                    Vungle.updateConsentStatus(Vungle.Consent.Undefined);
                    break;
                case UserConsent.Accept:
                    Vungle.updateConsentStatus(Vungle.Consent.Accepted);
                    break;
                case UserConsent.Deny:
                    Vungle.updateConsentStatus(Vungle.Consent.Denied);
                    break;
            }

            //load ads
            if (!string.IsNullOrEmpty(interstitialPlacementID))
            {
                Vungle.loadAd(interstitialPlacementID);
            }
            if (!string.IsNullOrEmpty(rewardedPlacementId))
            {
                Vungle.loadAd(rewardedPlacementId);
            }
            if (debug)
            {
                ScreenWriter.Write(this + " " + "Init Complete");
            }
        }


        private void OnAdRewarded(string placementID)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " OnAdRewarded " + placementID);
            }

            if (placementID == rewardedPlacementId)
            {
                if (OnCompleteMethod != null)
                {
                    OnCompleteMethod(true);
                    OnCompleteMethod = null;
                }
                if (OnCompleteMethodWithAdvertiser != null)
                {
                    OnCompleteMethodWithAdvertiser(true, SupportedAdvertisers.Vungle.ToString());
                    OnCompleteMethodWithAdvertiser = null;
                }
            }
        }


        private void OnAdEnd(string placementID)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " OnAdEnd " + placementID);
            }

            if (placementID == rewardedPlacementId)
            {
                if (OnCompleteMethod != null)
                {
                    OnCompleteMethod(false);
                    OnCompleteMethod = null;
                }
                if (OnCompleteMethodWithAdvertiser != null)
                {
                    OnCompleteMethodWithAdvertiser(false, SupportedAdvertisers.Vungle.ToString());
                    OnCompleteMethodWithAdvertiser = null;
                }
                if (debug)
                {
                    ScreenWriter.Write(this + " Load another ad " + placementID);
                }
                Vungle.loadAd(rewardedPlacementId);
            }

            if (placementID == interstitialPlacementID)
            {
                if (OnInterstitialClosed != null)
                {
                    OnInterstitialClosed();
                    OnInterstitialClosed = null;
                }

                if (OnInterstitialClosedWithAdvertiser != null)
                {
                    OnInterstitialClosedWithAdvertiser(SupportedAdvertisers.Vungle.ToString());
                    OnInterstitialClosedWithAdvertiser = null;
                }
                if (debug)
                {
                    ScreenWriter.Write(this + " Load another ad " + placementID);
                }

                Vungle.loadAd(interstitialPlacementID);
            }
        }

        private void AdPlayableEvent(string placementID, bool adPlayable)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " Ad's playable state has been changed! placementID " + placementID + ". Now: " + adPlayable);
            }
        }


        private void OnPlacementPreparedEvent(string arg1, string arg2)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " OnPlacementPreparedEvent " + arg1 + " " + arg2);
            }
        }


        private void OnErrorEvent(string message)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " OnErrorEvent -> " + message);
            }

            if (message.Contains(bannerPlacementID))
            {
                if (DisplayResult != null)
                {
                    DisplayResult(false, currentPosition, bannerType);
                    DisplayResult = null;
                }
                StopAllCoroutines();
            }

        }


        private void AdStarted(string placementID)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " AdStarted " + placementID);
            }
        }


        /// <summary>
        /// VUngle specific log event
        /// </summary>
        /// <param name="obj"></param>
        private void VungleLog(string obj)
        {
            if (debug)
            {
                ScreenWriter.Write(this + " " + obj);
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (focus == true)
            {
                if(initComplete==false)
                {
                    Vungle.init(appID);
                }
            }
        }

        #endregion

#else
        //dummy interface implementation, used when Vungle is not enabled
        public void HideBanner()
        {

        }

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {

        }

        public void ResetBannerUsage()
        {

        }

        public bool BannerAlreadyUsed()
        {
            return false;
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
