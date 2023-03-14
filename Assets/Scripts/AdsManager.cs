using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Ads;
    public void Showintertitial()
    {
        Advertisements.Instance.ShowInterstitial();
    }
    public void ShowrewardVideo()
    {
        Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
        void CompleteMethod(bool completed, string advertiser)
        {
            Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
            if (completed == true)
            {
                //give the reward
            }
            else
            {
                //no reward
            }
        }
    }
}
