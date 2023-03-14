using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [Header("Manaegr")]
    public GameObject Level1;
    public swipe ManagerS;
    public SelectMapManager Map;
    public Image IconLevels;
    public Button Swip;
    public GameObject ButtonsActive;
    internal bool M1 = true;
    internal bool M2 = true;
    internal bool M3 = true;
    internal bool M4 = true;
    internal bool M5 = true;
    internal bool M6 = true;

    [Header("ListedLevels")]
    public GameObject[] Levels;

    void Update()
    {
        if (ManagerS.Number == 0)
        {
            if (IconLevels.sprite == Map.P1.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 0 && M1 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level);
            M1 = false;
            ///
            M2 = true;
            M3 = true;
            M4 = true;
            M5 = true;
            M6 = true;
        }
        if (ManagerS.Number == 1)
        {
            if (IconLevels.sprite == Map.P2.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 1 && M2 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level2);
            M2 = false;
            ///
            M1 = true;
            M3 = true;
            M4 = true;
            M5 = true;
            M6 = true;
        }
        if (ManagerS.Number == 2)
        {
            if (IconLevels.sprite == Map.P3.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 2 && M3 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level3);
            M3 = false;
            ///
            M2 = true;
            M1 = true;
            M4 = true;
            M5 = true;
            M6 = true;
        }
        if (ManagerS.Number == 3)
        {
            if (IconLevels.sprite == Map.P4.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 3 && M4 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level4);
            M4 = false;
            ///
            M2 = true;
            M3 = true;
            M1 = true;
            M5 = true;
            M6 = true;
        }
        if (ManagerS.Number == 4)
        {
            if (IconLevels.sprite == Map.P5.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 4 && M5 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level5);
            M5 = false;
            ///
            M2 = true;
            M3 = true;
            M4 = true;
            M1 = true;
            M6 = true;
        }
        if (ManagerS.Number == 5)
        {
            if (IconLevels.sprite == Map.P6.sprite)
            {
                ButtonsActive.SetActive(true);
            }
            else
            {
                ButtonsActive.SetActive(false);
            }
        }
        if (ManagerS.Number == 5 && M6 == true)
        {
            Swip.onClick.RemoveAllListeners();
            Swip.onClick.AddListener(Level6);
            M6 = false;
            ///
            M2 = true;
            M3 = true;
            M4 = true;
            M5 = true;
            M1 = true;
        }
    }
    public void Level()
    {
        Level1 = Levels[0];
        Map.IconFirst.sprite = Map.P1.sprite;
        Map.HeaderTitile.text = "1.wild Streets";
        Map.HeaderTitle.text = "1.wild Streets";
    }
    public void Level2()
    {
        Level1 = Levels[1];
        Map.IconFirst.sprite = Map.P2.sprite;
        Map.HeaderTitile.text = "2.Jungle War";
        Map.HeaderTitle.text = "2.Jungle War";
    }
    public void Level3()
    {
        Level1 = Levels[2];
        Map.IconFirst.sprite = Map.P3.sprite;
        Map.HeaderTitile.text = "3.wild Road";
        Map.HeaderTitle.text = "3.wild Road";
    }
    public void Level4()
    {
        Level1 = Levels[3];
        Map.IconFirst.sprite = Map.P4.sprite;
        Map.HeaderTitile.text = "4.desert boombs";
        Map.HeaderTitle.text = "4.desert boombs";
    }
    public void Level5()
    {
        Level1 = Levels[4];
        Map.IconFirst.sprite = Map.P5.sprite;
        Map.HeaderTitile.text = "5.Enemy Streets";
        Map.HeaderTitle.text = "5.Enemy Streets";
    }
    public void Level6()
    {
        Level1 = Levels[5];
        Map.IconFirst.sprite = Map.P6.sprite;
        Map.HeaderTitle.text = "6.container  Soliders";
        Map.HeaderTitile.text = "6.container  Soliders";
    }
}
