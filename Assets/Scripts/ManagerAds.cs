using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerAds : MonoBehaviour
{
    public SelectMapManager Manager;

    public GameObject Btn;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;
    public GameObject M5;
    public GameObject M6;

    internal bool Active1 = true;
    internal bool Active2 = true;
    internal bool Active3 = true;
    internal bool Active4 = true;
    internal bool Active5 = true;

    internal bool B1 = false;
    internal bool B2 = false;
    internal bool B3 = false;
    internal bool B4 = false;
    internal bool B5 = false;
    void Update()
    {
        if(Manager.ManagerValue.Number == 0)
        {
            Btn.SetActive(false);
        }
        else
        {
            if(Manager.ManagerValue.Number == 1)
            {
                if(Active1 == true)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Btn.SetActive(false);
                }
                if (B1 == false)
                {
                    Btn.GetComponent<Button>().onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().onClick.AddListener(Check1);
                    B2 = false;
                    B3 = false;
                    B4 = false;
                    B5 = false;
                    B1 = true;
                }
            }
            if (Manager.ManagerValue.Number == 2)
            {
                if (Active2 == true)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Btn.SetActive(false);
                }
                if (B2 == false)
                {
                    Btn.GetComponent<Button>().onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().onClick.AddListener(Check2);
                    B2 = true;
                    B3 = false;
                    B4 = false;
                    B5 = false;
                    B1 = false;
                }
            }
            if (Manager.ManagerValue.Number == 3)
            {
                if (Active3 == true)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Btn.SetActive(false);
                }
                if (B3 == false)
                {
                    Btn.GetComponent<Button>().onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().onClick.AddListener(Check3);
                    B2 = false;
                    B3 = true;
                    B4 = false;
                    B5 = false;
                    B1 = false;
                }
            }
            if (Manager.ManagerValue.Number == 4)
            {
                if (Active4 == true)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Btn.SetActive(false);
                }
                if (B4 == false)
                {
                    Btn.GetComponent<Button>().onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().onClick.AddListener(Check4);
                    B2 = false;
                    B3 = false;
                    B4 = true;
                    B5 = false;
                    B1 = false;
                }
            }
            if (Manager.ManagerValue.Number == 5)
            {
                if (Active5 == true)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Btn.SetActive(false);
                }
                if (B5 == false)
                {
                    Btn.GetComponent<Button>().onClick.RemoveAllListeners();
                    Btn.GetComponent<Button>().onClick.AddListener(Check5);
                    B2 = false;
                    B3 = false;
                    B4 = false;
                    B5 = true;
                    B1 = false;
                }
            }
        }
    }

    void Check1()
    {
        Active1 = false;
        M2.SetActive(false);
        Btn.SetActive(false);
    }
    void Check2()
    {
        Active2 = false;
        M3.SetActive(false);
        Btn.SetActive(false);
    }
    void Check3()
    {
        Active3 = false;
        M4.SetActive(false);
        Btn.SetActive(false);
    }
    void Check4()
    {
        Active4 = false;
        M5.SetActive(false);
        Btn.SetActive(false);
    }
    void Check5()
    {
        Active5 = false;
        M6.SetActive(false);
        Btn.SetActive(false);
    }

}
