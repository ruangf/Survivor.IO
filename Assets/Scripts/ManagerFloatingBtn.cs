using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics.Tracing;

public class ManagerFloatingBtn : MonoBehaviour
{
    [Header("Managers")]
    public GameManager Manager;

    [Header("Buttons Objects")]
    public GameObject FirstBtn;
    public GameObject FirstMinseBtn;
    public GameObject CenterBtn;
    public GameObject SecondBtn;
    public GameObject ThirdBtn;

    [Header("Logo Manager")]
    public GameObject LogFirst;
    public GameObject LogFirstMinse;
    public GameObject LogCenter;
    public GameObject LogSecond;
    public GameObject LogThird;

    [Header("Lock Icon")]
    public GameObject LockEvolve;
    public GameObject LockShope;
    public GameObject LockEquipement;
    public GameObject LockDeath;

    [Header("Named Vectors")]
    public GameObject TextFirst;
    public GameObject TextFirstMinse;
    public GameObject TextCenter;
    public GameObject TextSecond;
    public GameObject TextThird;

    [Header("Buttons")]
    public Button BtnCenter;
    public Button Evolvebtn;
    public Button shopbtn;
    public Button equipementbtn;
    public Button deathbtn;

    [Header("Sprites")]
    public Sprite Inactive;
    public Sprite Active;

    [Header("Internal boolean")]
    internal bool Evolve = false;
    internal bool Shop = false;
    internal bool Equipement = false;
    internal bool Death = false;
    internal bool CheckFix = true;


    void Awake()
    {

    }
    private void OnEnable()
    {
        LogCenter.GetComponent<Animator>().Play("VectorBattleBack");
    }
    void Start()
    {
        BtnCenter.onClick.Invoke();
        Evolvebtn.onClick.Invoke();
        shopbtn.onClick.Invoke();
        equipementbtn.onClick.Invoke();
        deathbtn.onClick.Invoke();
        BtnCenter.onClick.Invoke();
        shopbtn.onClick.Invoke();
        LogCenter.GetComponent<Animator>().Play("VectorBattleBack");
        CheckFirsts();
    }
    void Update()
    {
        if(Evolve == false)
        {
            LockEvolve.SetActive(true);
            LogThird.SetActive(false);
            TextThird.SetActive(false);
        }
        else
        {
            LockEvolve.SetActive(false);
            LogThird.SetActive(true);
        }
        if(Shop == false)
        {
            LockShope.SetActive(true);
            LogFirst.SetActive(false);
            TextFirst.SetActive(false);
        }
        else
        {
            LockShope.SetActive(false);
            LogFirst.SetActive(true);
        }
        if(Equipement == false)
        {
            LockEquipement.SetActive(true);
            LogFirstMinse.SetActive(false);
        }
        else
        {
            LockEquipement.SetActive(false);
            LogFirstMinse.SetActive(true);
        }
        if(Death == false)
        {
            LockDeath.SetActive(true);
            LogSecond.SetActive(false);
        }
        else
        {
            LockDeath.SetActive(false);
            LogSecond.SetActive(true);
        }
        CheckActive();
    }

    void CheckActive()
    {

    }
    void CheckFirsts()
    {
        if (FirstBtn.GetComponent<Image>().sprite == Inactive && Shop == true)
        {
            LogFirst.SetActive(true);
            LogFirst.GetComponent<Animator>().Play("VectorBattle");
        }
        if (FirstMinseBtn.GetComponent<Image>().sprite == Inactive && Equipement == true)
        {
            LogFirstMinse.SetActive(true);
            LogFirstMinse.GetComponent<Animator>().Play("VectorBattle");
        }
        if (SecondBtn.GetComponent<Image>().sprite == Inactive && Death == true)
        {
            LogSecond.SetActive(true);
            LogSecond.GetComponent<Animator>().Play("VectorBattle");
        }
        if (ThirdBtn.GetComponent<Image>().sprite == Inactive && Evolve == true)
        {
            LogThird.SetActive(true);
            LogThird.GetComponent<Animator>().Play("VectorBattle");CheckCenter();CheckFirst();CheckCenter();
        }
    }
    public void CheckCenter()
    {
        Manager.ScreenHome.SetActive(true);
        Manager.ScreenShop.SetActive(false);
        Manager.ScreenDeath.SetActive(false);
        Manager.ScreenEquipement.SetActive(false);
        Manager.ScreenVolve.SetActive(false);
        if (CenterBtn.GetComponent<Image>().sprite == Inactive)
        {
            CenterBtn.GetComponent<Image>().sprite = Active;
            LogCenter.GetComponent<Animator>().Play("VectorBattleBack");
            TextCenter.SetActive(true);
            TextFirstMinse.SetActive(false);
            TextSecond.SetActive(false);
            TextThird.SetActive(false);
            TextFirst.SetActive(false);
        }
        /////
        if (FirstMinseBtn.GetComponent<Image>().sprite == Active)
        {
            LogFirstMinse.GetComponent<Animator>().Play("VectorBattle");
        }
        if (SecondBtn.GetComponent<Image>().sprite == Active)
        {
            LogSecond.GetComponent<Animator>().Play("VectorBattle");
        }
        if (ThirdBtn.GetComponent<Image>().sprite == Active)
        {
            LogThird.GetComponent<Animator>().Play("VectorBattle");
        }
        if(FirstBtn.GetComponent<Image>().sprite == Active)
        {
            LogFirst.GetComponent<Animator>().Play("VectorBattle");
        }

        FirstBtn.GetComponent<Image>().sprite = Inactive;
        FirstMinseBtn.GetComponent<Image>().sprite = Inactive;
        SecondBtn.GetComponent<Image>().sprite = Inactive;
        ThirdBtn.GetComponent<Image>().sprite = Inactive;
    }
    public void CheckFirst()
    {
        if (Shop == true)
        {
            Manager.ScreenHome.SetActive(false);
            Manager.ScreenShop.SetActive(true);
            Manager.ScreenDeath.SetActive(false);
            Manager.ScreenEquipement.SetActive(false);
            Manager.ScreenVolve.SetActive(false);
            if (FirstBtn.GetComponent<Image>().sprite == Inactive)
            {
                FirstBtn.GetComponent<Image>().sprite = Active;
                LogFirst.GetComponent<Animator>().Play("VectorBattleBack");
                TextFirst.SetActive(true);
                TextCenter.SetActive(false);
                TextFirstMinse.SetActive(false);
                TextSecond.SetActive(false);
                TextThird.SetActive(false);
            }
            /////
            if (CenterBtn.GetComponent<Image>().sprite == Active)
            {
                LogCenter.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstMinseBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirstMinse.GetComponent<Animator>().Play("VectorBattle");
            }
            if (SecondBtn.GetComponent<Image>().sprite == Active)
            {
                LogSecond.GetComponent<Animator>().Play("VectorBattle");
            }
            if (ThirdBtn.GetComponent<Image>().sprite == Active)
            {
                LogThird.GetComponent<Animator>().Play("VectorBattle");
            }

            FirstMinseBtn.GetComponent<Image>().sprite = Inactive;
            SecondBtn.GetComponent<Image>().sprite = Inactive;
            ThirdBtn.GetComponent<Image>().sprite = Inactive;
            CenterBtn.GetComponent<Image>().sprite = Inactive;
        }
    }
    public void CheckFirstMinse()
    {
        if(Equipement == true)
        {
            Manager.ScreenHome.SetActive(false);
            Manager.ScreenShop.SetActive(false);
            Manager.ScreenEquipement.SetActive(true);
            Manager.ScreenDeath.SetActive(false);
            Manager.ScreenVolve.SetActive(false);
            if (FirstMinseBtn.GetComponent<Image>().sprite == Inactive)
            {
                FirstMinseBtn.GetComponent<Image>().sprite = Active;
                LogFirstMinse.GetComponent<Animator>().Play("VectorBattleBack");
                TextFirstMinse.SetActive(true);
                TextCenter.SetActive(false);
                TextFirst.SetActive(false);
                TextSecond.SetActive(false);
                TextThird.SetActive(false);
            }
            /////
            if (CenterBtn.GetComponent<Image>().sprite == Active)
            {
                LogCenter.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirst.GetComponent<Animator>().Play("VectorBattle");
            }
            if (SecondBtn.GetComponent<Image>().sprite == Active)
            {
                LogSecond.GetComponent<Animator>().Play("VectorBattle");
            }
            if (ThirdBtn.GetComponent<Image>().sprite == Active)
            {
                LogThird.GetComponent<Animator>().Play("VectorBattle");
            }
            CenterBtn.GetComponent<Image>().sprite = Inactive;
            FirstBtn.GetComponent<Image>().sprite = Inactive;
            SecondBtn.GetComponent<Image>().sprite = Inactive;
            ThirdBtn.GetComponent<Image>().sprite = Inactive;
        }
    }
    public void CheckSecond()
    {
        if(Death == true)
        {
            Manager.ScreenHome.SetActive(false);
            Manager.ScreenShop.SetActive(false);
            Manager.ScreenEquipement.SetActive(false);
            Manager.ScreenDeath.SetActive(true);
            Manager.ScreenVolve.SetActive(false);
            if (SecondBtn.GetComponent<Image>().sprite == Inactive)
            {
                SecondBtn.GetComponent<Image>().sprite = Active;
                LogSecond.GetComponent<Animator>().Play("VectorBattleBack");
                TextSecond.SetActive(true);
                TextCenter.SetActive(false);
                TextFirst.SetActive(false);
                TextFirstMinse.SetActive(false);
                TextThird.SetActive(false);
            }
            /////
            if (CenterBtn.GetComponent<Image>().sprite == Active)
            {
                LogCenter.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirst.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstMinseBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirstMinse.GetComponent<Animator>().Play("VectorBattle");
            }
            if (ThirdBtn.GetComponent<Image>().sprite == Active)
            {
                LogThird.GetComponent<Animator>().Play("VectorBattle");
            }
            CenterBtn.GetComponent<Image>().sprite = Inactive;
            FirstMinseBtn.GetComponent<Image>().sprite = Inactive;
            FirstBtn.GetComponent<Image>().sprite = Inactive;
            ThirdBtn.GetComponent<Image>().sprite = Inactive;
        }
    }
    public void CheckThird()
    {
        if(Evolve == true)
        {
            Manager.ScreenHome.SetActive(false);
            Manager.ScreenShop.SetActive(false);
            Manager.ScreenEquipement.SetActive(false);
            Manager.ScreenDeath.SetActive(false);
            Manager.ScreenVolve.SetActive(true);
            if (ThirdBtn.GetComponent<Image>().sprite == Inactive)
            {
                ThirdBtn.GetComponent<Image>().sprite = Active;
                LogThird.GetComponent<Animator>().Play("VectorBattleBack");
                LogCenter.GetComponent<Animator>().Play("VectorBattle");
                TextThird.SetActive(true);
                TextCenter.SetActive(false);
                TextFirst.SetActive(false);
                TextFirstMinse.SetActive(false);
                TextSecond.SetActive(false);
            }
            /////
            if (CenterBtn.GetComponent<Image>().sprite == Active)
            {
                LogCenter.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirst.GetComponent<Animator>().Play("VectorBattle");
            }
            if (FirstMinseBtn.GetComponent<Image>().sprite == Active)
            {
                LogFirstMinse.GetComponent<Animator>().Play("VectorBattle");
            }
            if (SecondBtn.GetComponent<Image>().sprite == Active)
            {
                LogSecond.GetComponent<Animator>().Play("VectorBattle");
            }
            SecondBtn.GetComponent<Image>().sprite = Inactive;
            FirstMinseBtn.GetComponent<Image>().sprite = Inactive;
            FirstBtn.GetComponent<Image>().sprite = Inactive;
            CenterBtn.GetComponent<Image>().sprite = Inactive;
        }
    }
}
