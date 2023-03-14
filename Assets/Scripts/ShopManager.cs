using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ManagerMecanique Mecanique;

    public Button btn0;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public void Geems()
    {
        Mecanique.GemsInt = Mecanique.GemsInt * 3;
        btn0.interactable = false;
    }
    public void WeaponDesign()
    {
        btn1.interactable = false;
        if(Mecanique.CoinsInt > 400)
        {
            Mecanique.CoinsInt -= 400;
        }
    }
    public void BonePendant()
    {
        btn2.interactable = false;
        Mecanique.CoinsInt = Mecanique.CoinsInt * 20;
    }
    public void BoneM()
    {
        btn3.interactable = false;
    }
    public void ClothingDesign()
    {
        btn4.interactable = false;
        if(Mecanique.CoinsInt > 5000)
        {
            Mecanique.CoinsInt -= 5000;
        }
    }
    public void ShoesDesign()
    {
        btn5.interactable = false;
    }
}
