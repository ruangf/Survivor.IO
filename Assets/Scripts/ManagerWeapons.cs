using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ManagerWeapons : MonoBehaviour
{
    [Header("Managers")]
    public SpriteWeapons WeaponsManager;
    public GameManager FillingScore;

    [Header("Manager Componenet Addons")]
    public GameObject GameAddonsWeapons;

    [Header("Buttons GamePlay")]
    public GameObject FirstBtn;
    public GameObject SecondBtn;
    public GameObject ThirdBtn;

    [Header("Names")]
    public Text NameOne;
    public Text NameTwo;
    public Text NameThree;

    [Header("Images")]
    public Image IconOne;
    public Image IconTwo;
    public Image IconThree;

    [Header("Description")]
    public TextMeshProUGUI DescriptionOne;
    public TextMeshProUGUI DescriptionTwo;
    public TextMeshProUGUI DescriptionThree;

    [Header("ShootYollow")]
    public GameObject YSpriteOne;
    public GameObject YSpriteTwo;
    public GameObject YSpriteThree;
    public GameObject YSpriteFour;
    public GameObject YSpriteFive;
    public GameObject YSpriteSix;

    [Header("ShootGreen")]
    public GameObject GSpriteOne;
    public GameObject GSpriteTwo;
    public GameObject GSpriteThree;
    public GameObject GSpriteFour;
    public GameObject GSpriteFive;
    public GameObject GSpriteSix;

    [Header("Int Managers")]
    public int PauseFirst;
    public int PauseSecond;
    public int PauseThrees;

    [Header("Boolean Manager")]
    internal bool ActivateWeapon = true;

    void Start()
    {

    }
    void Update()
    {
        if (ActivateWeapon == true)
        {
            if(FillingScore.ScoringLevel.fillAmount == 1)
            {
                PauseFirst = Random.Range(1, 12);
                PauseSecond = Random.Range(1, 12);
                PauseThrees = Random.Range(1, 12);
                PauseOne();
                PauseTwo();
                PauseThree();
                ActivateWeapon = false;
            }
        }
    }
    void PauseOne()
    {
        ManagerFirstPlace();
    }
    void PauseTwo()
    {
        ManagerSecondPlace();
    }
    void PauseThree()
    {
        ManagerThirdPlace();
    }

    /////////
    void ManagerThirdPlace()
    {
        if (PauseSecond == 1)
        {
            AguelThree();
        }
        if (PauseSecond == 2)
        {
            BallThree();
        }
        if (PauseSecond == 3)
        {
            BrikThree();
        }
        if (PauseSecond == 4)
        {
            DroneAThree();
        }
        if (PauseSecond == 5)
        {
            DroneBThree();
        }
        if (PauseSecond == 6)
        {
            DroneCThree();
        }
        if (PauseSecond == 7)
        {
            FireGaseThree();
        }
        if (PauseSecond == 8)
        {
            FireShanShonThree();
        }
        if (PauseSecond == 9)
        {
            GunThree();
        }
        if (PauseSecond == 10)
        {
            ProtecteurThree();
        }
        if (PauseSecond == 11)
        {
            SprineAThree();
        }
        if (PauseSecond == 12)
        {
            SprineBThree();
        }
    }
    void ManagerSecondPlace()
    {
        if (PauseSecond == 1)
        {
            AguelTwo();
        }
        if (PauseSecond == 2)
        {
            BallTwo();
        }
        if (PauseSecond == 3)
        {
            BrikWallTwo();
        }
        if (PauseSecond == 4)
        {
            DroneATwo();
        }
        if (PauseSecond == 5)
        {
            DroneBTwo();
        }
        if (PauseSecond == 6)
        {
            DroneCTow();
        }
        if (PauseSecond == 7)
        {
            FireGaaseTwo();
        }
        if (PauseSecond == 8)
        {
            FireShanshonTwo();
        }
        if (PauseSecond == 9)
        {
            GunTwo();
        }
        if (PauseSecond == 10)
        {
            ProtecteurTwo();
        }
        if (PauseSecond == 11)
        {
            SprineATwo();
        }
        if (PauseSecond == 12)
        {
            SprineBTwo();
        }
    }
    void ManagerFirstPlace()
    {
        if(PauseFirst == 1)
        {
            AguelOne();
        }
        if (PauseFirst == 2)
        {
            BallOne();
        }
        if (PauseFirst == 3)
        {
            BrikWallOne();
        }
        if (PauseFirst == 4)
        {
            DroneAOne();
        }
        if (PauseFirst == 5)
        {
            DroneBOne();
        }
        if (PauseFirst == 6)
        {
            DroneCOne();
        }
        if (PauseFirst == 7)
        {
            FireGaseOne();
        }
        if (PauseFirst == 8)
        {
            FireShanshonOne();
        }
        if (PauseFirst == 9)
        {
            GunOne();
        }
        if (PauseFirst == 10)
        {
            ProtecteurOne();
        }
        if (PauseFirst == 11)
        {
            SprineAOne();
        }
        if (PauseFirst == 12)
        {
            SprineBOne();
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    
    public void ClearButton()
    {
        StartCoroutine(FinishingCleaning());
    }
    IEnumerator FinishingCleaning()
    {
        yield return new WaitForSeconds(1f);
        FirstBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        SecondBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        ThirdBtn.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    /////////////
    void AguelOne()
    {
        NameOne.text = WeaponsManager.Naguel;
        DescriptionOne.text = WeaponsManager.DAguel;
        IconOne.sprite = WeaponsManager.SAguel;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    void AguelTwo()
    {
        NameTwo.text = WeaponsManager.Naguel;
        DescriptionTwo.text = WeaponsManager.DAguel;
        IconTwo.sprite = WeaponsManager.SAguel;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    void AguelThree()
    {
        NameThree.text = WeaponsManager.Naguel;
        DescriptionThree.text = WeaponsManager.DAguel;
        IconThree.sprite = WeaponsManager.SAguel;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    /////
    void FireGaseOne()
    {
        NameOne.text = WeaponsManager.NFireGase;
        DescriptionOne.text = WeaponsManager.DFireGase;
        IconOne.sprite = WeaponsManager.SFireGase;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    void FireGaaseTwo()
    {
        NameTwo.text = WeaponsManager.NFireGase;
        DescriptionTwo.text = WeaponsManager.DFireGase;
        IconTwo.sprite = WeaponsManager.SFireGase;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    void FireGaseThree()
    {
        NameThree.text = WeaponsManager.NFireGase;
        DescriptionThree.text = WeaponsManager.DFireGase;
        IconThree.sprite = WeaponsManager.SFireGase;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    /////
    void FireShanshonOne()
    {
        NameOne.text = WeaponsManager.NSalsaRanshon;
        DescriptionOne.text = WeaponsManager.DSalsaRanshon;
        IconOne.sprite = WeaponsManager.SSalsaRanshone;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    void FireShanshonTwo()
    {
        NameTwo.text = WeaponsManager.NSalsaRanshon;
        DescriptionTwo.text = WeaponsManager.DSalsaRanshon;
        IconTwo.sprite = WeaponsManager.SSalsaRanshone;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    void FireShanShonThree()
    {
        NameThree.text = WeaponsManager.NSalsaRanshon;
        DescriptionThree.text = WeaponsManager.DSalsaRanshon;
        IconThree.sprite = WeaponsManager.SSalsaRanshone;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    ////
    void BallOne()
    {
        NameOne.text = WeaponsManager.NBall;
        DescriptionOne.text = WeaponsManager.DBall;
        IconOne.sprite = WeaponsManager.SBall;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    void BallTwo()
    {
        NameTwo.text = WeaponsManager.NBall;
        DescriptionTwo.text = WeaponsManager.DBall;
        IconTwo.sprite = WeaponsManager.SBall;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    void BallThree()
    {
        NameThree.text = WeaponsManager.NBall;
        DescriptionThree.text = WeaponsManager.DBall;
        IconThree.sprite = WeaponsManager.SBall;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    //////
    void SprineBOne()
    {
        NameOne.text = WeaponsManager.NSprineB;
        DescriptionOne.text = WeaponsManager.DSprineB;
        IconOne.sprite = WeaponsManager.SSprineB;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    void SprineBTwo()
    {
        NameTwo.text = WeaponsManager.NSprineB;
        DescriptionTwo.text = WeaponsManager.DSprineB;
        IconTwo.sprite = WeaponsManager.SSprineB;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    void SprineBThree()
    {
        NameThree.text = WeaponsManager.NSprineB;
        DescriptionThree.text = WeaponsManager.DSprineB;
        IconThree.sprite = WeaponsManager.SSprineB;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    //////
    void SprineAOne()
    {
        NameOne.text = WeaponsManager.NSprineA;
        DescriptionOne.text = WeaponsManager.DSprineA;
        IconOne.sprite = WeaponsManager.SSprineA;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    void SprineATwo()
    {
        NameTwo.text = WeaponsManager.NSprineA;
        DescriptionTwo.text = WeaponsManager.DSprineA;
        IconTwo.sprite = WeaponsManager.SSprineA;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    void SprineAThree()
    {
        NameThree.text = WeaponsManager.NSprineA;
        DescriptionThree.text = WeaponsManager.DSprineA;
        IconThree.sprite = WeaponsManager.SSprineA;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    ////
    void GunOne()
    {
        NameOne.text = WeaponsManager.NGun;
        DescriptionOne.text = WeaponsManager.DGun;
        IconOne.sprite = WeaponsManager.SGun;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    void GunTwo()
    {
        NameTwo.text = WeaponsManager.NGun;
        DescriptionTwo.text = WeaponsManager.DGun;
        IconTwo.sprite = WeaponsManager.SGun;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    void GunThree()
    {
        NameThree.text = WeaponsManager.NGun;
        DescriptionThree.text = WeaponsManager.DGun;
        IconThree.sprite = WeaponsManager.SGun;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    ////////////
    void BrikWallOne()
    {
        NameOne.text = WeaponsManager.NBrikeWall;
        DescriptionOne.text = WeaponsManager.DBrikWall;
        IconOne.sprite = WeaponsManager.SBrikWall;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    void BrikWallTwo()
    {
        NameTwo.text = WeaponsManager.NBrikeWall;
        DescriptionTwo.text = WeaponsManager.DBrikWall;
        IconTwo.sprite = WeaponsManager.SBrikWall;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    void BrikThree()
    {
        NameThree.text = WeaponsManager.NBrikeWall;
        DescriptionThree.text = WeaponsManager.DBrikWall;
        IconThree.sprite = WeaponsManager.SBrikWall;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    /////////
    void DroneAOne()
    {
        NameOne.text = WeaponsManager.NDroneA;
        DescriptionOne.text = WeaponsManager.DDroneA;
        IconOne.sprite = WeaponsManager.SDroneA;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    void DroneATwo()
    {
        NameTwo.text = WeaponsManager.NDroneA;
        DescriptionTwo.text = WeaponsManager.DDroneA;
        IconTwo.sprite = WeaponsManager.SDroneA;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    void DroneAThree()
    {
        NameThree.text = WeaponsManager.NDroneA;
        DescriptionThree.text = WeaponsManager.DDroneA;
        IconThree.sprite = WeaponsManager.SDroneA;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    /////////////////////
    void DroneBOne()
    {
        NameOne.text = WeaponsManager.NDroneB;
        DescriptionOne.text = WeaponsManager.DDroneB;
        IconOne.sprite = WeaponsManager.SDroneB;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    void DroneBTwo()
    {
        NameTwo.text = WeaponsManager.NDroneB;
        DescriptionTwo.text = WeaponsManager.DDroneB;
        IconTwo.sprite = WeaponsManager.SDroneA;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    void DroneBThree()
    {
        NameThree.text = WeaponsManager.NDroneB;
        DescriptionThree.text = WeaponsManager.DDroneB;
        IconThree.sprite = WeaponsManager.SDroneB;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    /////////////////////
    void DroneCOne()
    {
        NameOne.text = WeaponsManager.NDroneC;
        DescriptionOne.text = WeaponsManager.DDroneC;
        IconOne.sprite = WeaponsManager.SDroneC;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    void DroneCTow()
    {
        NameTwo.text = WeaponsManager.NDroneC;
        DescriptionTwo.text = WeaponsManager.DDroneC;
        IconTwo.sprite = WeaponsManager.SDroneC;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    void DroneCThree()
    {
        NameThree.text = WeaponsManager.NDroneC;
        DescriptionThree.text = WeaponsManager.DDroneC;
        IconThree.sprite = WeaponsManager.SDroneC;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    /////////////////////
    void ProtecteurOne()
    {
        NameOne.text = WeaponsManager.NProtecteurGreen;
        DescriptionOne.text = WeaponsManager.DProtecteurGreen;
        IconOne.sprite = WeaponsManager.SProtecteurGreen;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }
    void ProtecteurTwo()
    {
        NameTwo.text = WeaponsManager.NProtecteurGreen;
        DescriptionTwo.text = WeaponsManager.DProtecteurGreen;
        IconTwo.sprite = WeaponsManager.SProtecteurGreen;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }
    void ProtecteurThree()
    {
        NameThree.text = WeaponsManager.NProtecteurGreen;
        DescriptionThree.text = WeaponsManager.DProtecteurGreen;
        IconThree.sprite = WeaponsManager.SProtecteurGreen;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }
}
