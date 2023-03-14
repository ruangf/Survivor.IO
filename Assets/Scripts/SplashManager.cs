using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplashManager : MonoBehaviour
{
    [Header("Componenet")]
    public Image FillingBar;
    public Text Value;
    public Text Narratore;
    public Text Version;

    [Header("Floating Manager")]
    internal float ValueBar;

    [Header("Strings Manager")]
    internal string CurrentChecking = "Loading";

    [Header("Int Manager")]
    internal int ValuePercentage;

    [Header("Boolean Manager")]
    internal bool GameLoaded = false;


    void Start()
    {
        StartCoroutine(FillingController());
        StartCoroutine(TextNarrator());
    }
    void Update()
    {
        if(GameLoaded == false)
        {
            FillingBar.fillAmount = ValueBar / 100;
            Value.text = (int)ValueBar + "%";
            if(FillingBar.fillAmount == 1)
            {
               // Debug.Log("Game Loaded");
                GameLoaded = true;
            }
        }
    }
    IEnumerator TextNarrator()
    {
        if(GameLoaded == false)
        {
            yield return new WaitForSeconds(0.3f);
            Narratore.text = CurrentChecking;
            yield return new WaitForSeconds(0.3f);
            Narratore.text = CurrentChecking + ".";
            yield return new WaitForSeconds(0.3f);
            Narratore.text = CurrentChecking + "..";
            yield return new WaitForSeconds(0.3f);
            Narratore.text = CurrentChecking + "...";
            yield return new WaitForEndOfFrame();
            StartCoroutine(TextNarrator());
        }
    }
    IEnumerator FillingController()
    {
        if(GameLoaded == false)
        {
            yield return new WaitForSeconds(0.05f);
            ValueBar += 1;
            yield return new WaitForEndOfFrame();
            StartCoroutine(FillingController());
        }
    }
}
