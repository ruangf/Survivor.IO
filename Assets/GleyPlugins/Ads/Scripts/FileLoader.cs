namespace GleyMobileAds
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;

    public class FileLoader
    {
        private string result;
        /// <summary>
        /// Actual loading of external file
        /// </summary>
        /// <param name="url">the url to the config file</param>
        /// <returns></returns>
        public IEnumerator LoadFile(string url, bool debug)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
#if UNITY_2020_1_OR_NEWER
            if (www.result == UnityWebRequest.Result.ConnectionError)
#else
            if (www.isNetworkError || www.isHttpError)
#endif
            {
                if (debug)
                {
                    Debug.LogWarning("Could not download config file " + www.error);
                    ScreenWriter.Write("Could not download config file " + www.error);
                }
            }
            else
            {
                result = www.downloadHandler.text;
            }
        }

        public string GetResult()
        {
            return result;
        }
    }
}