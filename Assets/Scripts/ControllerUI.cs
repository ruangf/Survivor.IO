using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUI : MonoBehaviour
{
    [Header("Managers")]
    public SplashManager manager;

    [Header("Component")]
    public GameObject ScreenSplash;
    public GameObject ScreenMainMenu;
    public GameObject ScreenGamePlay;
    public GameObject Audio;

    [Header("Boolean Manager")]
    internal bool CheckSplash = true;
    internal bool CheckGamePlay = true;
    internal bool ActivateMusic = true;

    void Awake()
    {
        Advertisements.Instance.Initialize();
    }
    void Update()
    {
        if(CheckSplash == true && manager.GameLoaded == true)
        {
            ScreenSplash.SetActive(false);
            ScreenMainMenu.SetActive(true);
            if(ActivateMusic == true)
            {
                Audio.SetActive(true);
                ActivateMusic = false;
            }
            CheckSplash = false;
        }
        if(CheckGamePlay == true && this.gameObject.GetComponent<GameManager>().GameStart == true)
        {
            ScreenSplash.SetActive(false);
            ScreenMainMenu.SetActive(false);
            ScreenGamePlay.SetActive(true);
            CheckGamePlay = false;
        }
    }
}
