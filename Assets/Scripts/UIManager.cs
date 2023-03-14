using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    public GameManager Manager;
    public TimerManager timer;
    public BooleanManager Bool;
    public LevelsManager Level;
    public SpriteWeapons Weapons;
    public ManagerMecanique Mecanique;

    [Header("Componenet Player")]
    public GameObject Player;
    public GameObject HelthUI;
    public GameObject LevelLocalisation;
    public GameObject CurrentLevel;

    [Header("UI Manager")]
    public GameObject ScreenPause;
    public GameObject ScreenMainMenu;
    public GameObject ScreenGamePlay;
    public GameObject EffectFade;
    public GameObject EffectFadeGamePlay;
    public GameObject FinishScreen;

    [Header("Weapons Manager")]
    public GameObject SpinerContainer;
    public GameObject GunW;
    public GameObject SpinnerAW;
    public GameObject SpinnerBW;
    

    [Header("Sprites Guns")]
    public Sprite Sahem;
    public Sprite Gun;
    public Sprite SpinerA;
    public Sprite SpinerB;
    public Sprite Ball;
    public Sprite Rocket;
    public Sprite DroneA;
    public Sprite DroneB;
    public Sprite DroneC;
    public Sprite FireGlass;
    public Sprite Brick;
    public Sprite FireGase;

    [Header("Strings Manager")]
    internal string CheckEvolve;
    internal string Checking;
    public string CurrentName;

    [Header("Boolaen Manager")]
    internal bool FinishScreenB = false;
    internal bool DestroyEnemys = false;
    internal bool StopAllAudios = false;
    internal bool MapReady = false;
    void Start()
    {
        Checking = PlayerPrefs.GetString("CheckEvolve");
    }
    void Update()
    {
        CheckEvolve = PlayerPrefs.GetString("CheckEvolve");
        if (CheckEvolve == "work")
        {
            Manager.ManagerDownBtn.Evolve = true;
        }
        if(Manager.PlayerDeath == true && FinishScreenB == false)
        {
            DestroyEnemys = true;
            StopAllAudios = true;
            FinishScreen.SetActive(true);
            Advertisements.Instance.ShowInterstitial();
            Manager.PlayerDeath = false;
            Manager.Health = 100;
            Manager.HealthBar.color = Color.green;
            FinishScreenB = true;
        }
        else
        {
            StopAllAudios = false;
        }
            CurrentLevel = GameObject.Find(CurrentName);
    }
    public void BackBtn()
    {
        MapReady = false;
        EffectFadeGamePlay.SetActive(true);
        DestroyEnemys = true;
        Weapons.DesactivateAll();
        Destroy(CurrentLevel);
        StartCoroutine(StartBacking());
    }
    public void BackFinish()
    {
        MapReady = false;
        DestroyEnemys = true;
        EffectFadeGamePlay.SetActive(true);
        FinishScreen.SetActive(false);
        Weapons.DesactivateAll();
        Destroy(CurrentLevel);
        StartCoroutine(StartBacking());
        Advertisements.Instance.ShowInterstitial();
    }
    IEnumerator StartBacking()
    {
        yield return new WaitForSeconds(0.8f);
        Player.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        DestroyEnemys = false;
        Manager.CurrentReload = 0;
        Manager.CurrentCurrency = 0;
        Manager.CurrentKilled = 0;
        timer.timeRemaining = 0;
        FinishScreenB = false;
        EffectFadeGamePlay.SetActive(false);
        if (Manager.Boolean.GameStart == true)
        {
            Player.transform.position = new Vector3(0, 0, 0);
            HelthUI.SetActive(false);
            ScreenPause.SetActive(false);
            ScreenGamePlay.SetActive(false);
            ScreenMainMenu.SetActive(true);
            Manager.Boolean.GameStart = false;
        }
    }
    public void PlayBtn()
    {
        EffectFade.SetActive(true);
        (Instantiate(Level.Level1, Level.Level1.transform.position, Level.Level1.transform.rotation) as GameObject).transform.SetParent(LevelLocalisation.transform);
        CurrentName = Level.Level1.gameObject.name + "(Clone)";
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.7f);
        if(Checking == "")
        {
            Checking = "work";
        }
        if (CheckEvolve == "")
        {
            PlayerPrefs.SetString("CheckEvolve", Checking);
        }
        MapReady = true;
        Manager.startmove = true;
        EffectFade.SetActive(false);
        Bool.GameStart = true;
        Player.GetComponent<PlayerManager>().enabled = true;
        Manager.AvailabelWeapon = true;
        Manager.GameStart = true;
        ScreenMainMenu.SetActive(false);
        ScreenGamePlay.SetActive(true);
        HelthUI.SetActive(true);
        timer.timerIsRunning = true;
        if (Manager.EnemyAvailable == true)
        {
            Manager.startmove = false;
            foreach (GameObject joint in Manager.Enemys)
            {
                joint.GetComponent<EnemyManager>().enabled = true;
                joint.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
    public void Pause()
    {
        ScreenPause.SetActive(true);
        Manager.BtnPause();
    }
    public void Resume()
    {
        ScreenPause.SetActive(false);
        Manager.ResumeBtn();
    }
}
