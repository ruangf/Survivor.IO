using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Threading;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    [Header("Manager Controller")]
    public BooleanManager Boolean;
    public PlayerManager PlayerPerfb;
    public AudioManager Sounds;
    public movementJoystick JoystManager;
    public SpawenManager Spawner;
    public TimerManager Times;
    public ManagerFloatingBtn ManagerDownBtn;
    public ManagerWeapons WeaponSpawn;
    public UIManager ManagerUI;

    [Header("GameObject ScreenMainMenu")]
    public GameObject ScreenHome;
    public GameObject ScreenVolve;
    public GameObject ScreenShop;
    public GameObject ScreenDeath;
    public GameObject ScreenEquipement;

    [Header("Perfabes Controller")]
    public GameObject UIWeapon;
    public GameObject FillingFlash;
    public GameObject ScreenAddonWap;
    public GameObject[] Enemys;

    [Header("Levels World")]
    public GameObject ContainerWorld;

    [Header("UI Manager")]
    public Image HealthBar;
    public Image ReloadWeapon;
    public Image ScoringLevel;
    public Image FillingReweapon;
    public Color[] myColors;

    [Header("UI Text Manager")]
    public TextMeshProUGUI ScoringValue;
    public TextMeshProUGUI ScoringValueDeux;
    public TextMeshProUGUI ValueKilled;
    public Text ValueKilledScreenFinish;
    public TextMeshProUGUI CurrentCoins;

    [Header("Float Manager")]
    public float SpeedEnemy;
    internal float Valeur;
    internal float ValureLevel;
    public float LerpTime = 0.1f;
    internal float t = 0;
    internal float Health;

    [Header("Integer Manager")]
    internal int len;
    internal int colorIndex = 0;
    internal int CurrentKilled = 0;
    internal int CurrentCurrency = 0;
    internal int CurrentReload;

    [Header("Boolean Manager")]
    internal bool EnemyAvailable = true;
    internal bool SpawnObject = true;
    internal bool RightFill = true;
    internal bool LeftFill = true;

    internal bool NormalBolt = true;
    internal bool DiamondBolt = false;
    internal bool CheckFinish = true;
    internal bool StartFlashing = false;
    internal bool startmove = false;
    internal bool AvailabelWeapon = true;
    internal bool GameStart = false;
    internal bool SetActiveAll = true;
    internal bool PlayerDeath = false;
    internal bool Checkenemys = false;

    void Start()
    {
        len = myColors.Length;
        Health = 100f;
        ManagerDownBtn.Shop = true;
        ManagerDownBtn.Equipement = true;
        ManagerDownBtn.Death = true;

    }
    void Update()
    {
        if(Checkenemys == true)
        {

        }
        if(GameStart == true && SetActiveAll == true)
        {
            Boolean.GameStart = true;
            ContainerWorld.SetActive(true);
            UIWeapon.SetActive(true);
            SetActiveAll = false;
        }if(Boolean.GameStart == false)
        {
            Valeur = 0;
            ValureLevel = 0;
            ReloadWeapon.fillAmount = 0;
            ScoringLevel.fillAmount = 0;
        }
        if(Boolean.GameStart == true)
        {
            CheckEnemy();
            ReloadingWapeons();

            HealthBar.fillAmount = Health / 100f;
            if (HealthBar.fillAmount == 0.5f)
            {
                HealthBar.color = Color.yellow;
            }
            if (HealthBar.fillAmount == 0.3f)
            {
                HealthBar.color = Color.red;
            }
            if(HealthBar.fillAmount == 0 && PlayerDeath == false)
            {
                Debug.Log("You are Death");
                BtnPause();
                PlayerDeath = true;
            }
            ScoringValue.text = "" + CurrentReload;
            ScoringValueDeux.text = "" + CurrentReload;
            if (CheckFinish == true)
            {
                CheckValeurFill();
                if (ScoringLevel.fillAmount == 1)
                {
                    WeaponSpawn.PauseFirst = Random.Range(1, 12);
                    WeaponSpawn.PauseSecond = Random.Range(1, 12);
                    WeaponSpawn.PauseThrees = Random.Range(1, 12);
                    WeaponSpawn.ActivateWeapon = true;
                    Times.timerIsRunning = false;
                    CurrentReload += 1;
                    StartFlashing = true;
                    ScreenAddonWap.SetActive(true);
                    PlayerPerfb.GetComponent<PlayerManager>().enabled = false;
                    PlayerPerfb.GetComponent<Rigidbody2D>().simulated = false;
                    if (EnemyAvailable == true)
                    {
                        Spawner.enabled = false;
                        startmove = true;
                    }
                    ValureLevel = 0f;
                    CheckFinish = false;
                }
            }
            if (startmove == true)
            {
                foreach (GameObject joint in Enemys)
                {
                    joint.GetComponent<EnemyManager>().enabled = false;
                    joint.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
            if (StartFlashing == true)
            {
                FillingReweapon.color = Color.Lerp(FillingReweapon.color, myColors[colorIndex], LerpTime * Time.deltaTime);
                t = Mathf.Lerp(t, 1f, LerpTime * Time.deltaTime);
                if (t > 0.9f)
                {
                    t = 0;
                    colorIndex++;
                    colorIndex = (colorIndex >= len) ? 0 : colorIndex;
                }
            }
            CheckKilledAndCoins();
        }
    }
    public void BtnPause()
    {
        AvailabelWeapon = false;
        Times.timerIsRunning = false;
        PlayerPerfb.GetComponent<PlayerManager>().enabled = false;
        PlayerPerfb.GetComponent<Rigidbody2D>().simulated = false;
        if (EnemyAvailable == true)
        {
            Spawner.enabled = false;
            startmove = true;

        }
    }
    public void ResumeBtn()
    {
        AvailabelWeapon = true;
        Checkenemys = true;
        Times.timerIsRunning = true;
        PlayerPerfb.GetComponent<PlayerManager>().enabled = true;
        PlayerPerfb.GetComponent<Rigidbody2D>().simulated = true;
        if (EnemyAvailable == true)
        {
            startmove = false;
            Enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject joint in Enemys)
            {
                joint.GetComponent<EnemyManager>().enabled = true;
                joint.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
    void CheckKilledAndCoins()
    {
        ValueKilled.text =  "" + CurrentKilled;
        ValueKilledScreenFinish.text =  "" + CurrentKilled;
        CurrentCoins.text = "" + CurrentCurrency;
        PlayerPrefs.SetInt("CurrentKilled", CurrentKilled);
        PlayerPrefs.SetInt("CurrentCurrency", CurrentCurrency);

    }
    void CheckValeurFill()
    {
        if (CheckFinish == true)
        {
            ScoringLevel.fillAmount = ValureLevel / 50;
        }
    }
    void ReloadingWapeons()
    {    
        Valeur += 1f * Time.deltaTime;
        if(ReloadWeapon.fillAmount < 1 && RightFill == true)
        {
            SpawnObject = false;
            ReloadWeapon.fillAmount = Valeur;
            LeftFill = true;
        }
        if(ReloadWeapon.fillAmount == 1 && LeftFill == true)
        {
            SpawnObject = true;
            ReloadWeapon.fillAmount = 0;
            Valeur = 0;
            LeftFill = false;
        }
    }
    void CheckEnemy()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length == 0)
          {
            EnemyAvailable = false;
            NormalBolt = false;
            DiamondBolt = true;
          }
        else
          {
            EnemyAvailable = true;
            NormalBolt = true;
            DiamondBolt = false;
        }
    }
    public void FirstCont()
    {
        ScreenAddonWap.SetActive(false);
        Times.timerIsRunning = true;
        PlayerPerfb.GetComponent<PlayerManager>().enabled = true;
        PlayerPerfb.GetComponent<Rigidbody2D>().simulated = true;
        if (EnemyAvailable == true)
        {
            startmove = false;
            foreach (GameObject joint in Enemys)
            {
                joint.GetComponent<EnemyManager>().enabled = true;
                joint.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        ScoringLevel.fillAmount = 0;
        StartCoroutine(CheckingFinishBtn());
    }
    public void SecondCont()
    {
        ScreenAddonWap.SetActive(false);
        Times.timerIsRunning = true;
        PlayerPerfb.GetComponent<PlayerManager>().enabled = true;
        PlayerPerfb.GetComponent<Rigidbody2D>().simulated = true;
        if (EnemyAvailable == true)
        {
            startmove = false;
            foreach (GameObject joint in Enemys)
            {
                joint.GetComponent<EnemyManager>().enabled = true;
                joint.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        ScoringLevel.fillAmount = 0;
        StartCoroutine(CheckingFinishBtn());
    }
    public void ThirdCont()
    {
        ScreenAddonWap.SetActive(false);
        Times.timerIsRunning = true;
        PlayerPerfb.GetComponent<PlayerManager>().enabled = true;
        PlayerPerfb.GetComponent<Rigidbody2D>().simulated = true;
        //Spawner.enabled = true;
        if (EnemyAvailable == true)
        {
            startmove = false;
            foreach (GameObject joint in Enemys)
            {
                joint.GetComponent<EnemyManager>().enabled = true;
                joint.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        ScoringLevel.fillAmount = 0;
        StartCoroutine(CheckingFinishBtn());
    }

    IEnumerator CheckingFinishBtn()
    {
        yield return new WaitForSeconds(0.5f);
        CheckFinish = true;
    }
}
