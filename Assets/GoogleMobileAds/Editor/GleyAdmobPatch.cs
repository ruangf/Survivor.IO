using UnityEditor;

namespace GoogleMobileAds.Editor
{
    public class GleyAdmobPatch
    {
        public static void SetAdmobAppID(string androidAppId, string iosAppID)
        {
#if USE_ADMOB
            GoogleMobileAdsSettings.Instance.DelayAppMeasurementInit = true;
            GoogleMobileAdsSettings.Instance.GoogleMobileAdsAndroidAppId = androidAppId;
            GoogleMobileAdsSettings.Instance.GoogleMobileAdsIOSAppId = iosAppID;
            EditorUtility.SetDirty(GoogleMobileAdsSettings.Instance);
#endif
        }
    }
}