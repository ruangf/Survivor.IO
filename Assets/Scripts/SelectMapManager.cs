using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class SelectMapManager : MonoBehaviour
{
    [Header("Managers")]
    public swipe ManagerValue;
    public Animator Header;
    public Image IconFirst;
    public Text HeaderTitile;
    public Text HeaderTitle;
    public Text Description;

    [Header("Images")]
    public Color Black;
    public Color Normal;
    public Image P1;
    public Image P2;
    public Image P3;
    public Image P4;
    public Image P5;
    public Image P6;

    [Header("UI")]
    public Text Title;
    //0.75
    [Header("Boolean Manager")]
    internal bool Lev1 = false;
    internal bool Lev2 = false;
    internal bool Lev3 = false;
    internal bool Lev4 = false;
    internal bool Lev5 = false;
    internal bool Lev6 = false;
    void Start()
    {
        P1.color = Black;
        P2.color = Black;
        P3.color = Black;
        P4.color = Black;
        P5.color = Black;
        P6.color = Black;
    }
    void Update()
    {
        if(ManagerValue.Number == 0 && Lev1 == false)
        {
            P1.color = Normal;
            M1();
            P2.color = Black;
            P3.color = Black;
            P4.color = Black;
            P5.color = Black;
            P6.color = Black;
            Lev1 = true;
            Lev2 = false;
            Lev3 = false;
            Lev4 = false;
            Lev5 = false;
            Lev6 = false;
        }

        if (ManagerValue.Number == 1 && Lev2 == false)
        {
            P2.color = Normal;
            M2();
            P1.color = Black;
            P3.color = Black;
            P4.color = Black;
            P5.color = Black;
            P6.color = Black;
            Lev1 = false;
            Lev2 = true;
            Lev3 = false;
            Lev4 = false;
            Lev5 = false;
            Lev6 = false;
        }

        if (ManagerValue.Number == 2 && Lev3 == false)
        {
            P3.color = Normal;
            M3();
            P1.color = Black;
            P2.color = Black;
            P4.color = Black;
            P5.color = Black;
            P6.color = Black;
            Lev1 = false;
            Lev2 = false;
            Lev3 = true;
            Lev4 = false;
            Lev5 = false;
            Lev6 = false;
        }

        if (ManagerValue.Number == 3 && Lev4 == false)
        {
            P4.color = Normal;
            M4();
            P1.color = Black;
            P3.color = Black;
            P2.color = Black;
            P5.color = Black;
            P6.color = Black;
            Lev1 = false;
            Lev2 = false;
            Lev3 = false;
            Lev4 = true;
            Lev5 = false;
            Lev6 = false;
        }

        if (ManagerValue.Number == 4 && Lev5 == false)
        {
            P5.color = Normal;
            M5();
            P1.color = Black;
            P2.color = Black;
            P3.color = Black;
            P4.color = Black;
            P6.color = Black;
            Lev1 = false;
            Lev2 = false;
            Lev3 = false;
            Lev4 = false;
            Lev5 = true;
            Lev6 = false;
        }

        if (ManagerValue.Number == 5 && Lev6 == false)
        {
            P6.color = Normal;
            M6();
            P2.color = Black;
            P3.color = Black;
            P4.color = Black;
            P5.color = Black;
            P1.color = Black;
            Lev1 = false;
            Lev2 = false;
            Lev3 = false;
            Lev4 = false;
            Lev5 = false;
            Lev6 = true;
        }

    }
    void M1()
    {
        Header.Play("Header");
        Title.text = "1.wild Streets";
        Description.text = "The City is in chaos with the zombie horde\r\nroaming the streets.";
        P1.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P2.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P3.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P4.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P5.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P6.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    void M2()
    {
        Header.Play("Header");
        Title.text = "2.Jungle War";
        Description.text = "The jungl is in chaos with the monsters thats kill peopples.";
        P2.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P1.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P3.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P4.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P5.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P6.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    void M3()
    {
        Header.Play("Header");
        Title.text = "3.wild Road";
        Description.text = "You have to help soliders from attacking Zombies and monsters in Base.";
        P3.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P2.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P1.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P4.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P5.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P6.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    void M4()
    {
        Header.Play("Header");
        Title.text = "4.desert boombs";
        Description.text = "The desert Base its going on to Attack by Enemys.";
        P4.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P2.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P3.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P1.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P5.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P6.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    void M5()
    {
        Header.Play("Header");
        Title.text = "5.Enemy Streets";
        Description.text = "The Street its fulled With Z and M thats kill peopple Your Mission its to protect them.";
        P5.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P2.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P3.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P4.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P1.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P6.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    void M6()
    {
        Header.Play("Header");
        Title.text = "6.container  Soliders";
        Description.text = "Help the Container soliders to finish killing Zombies and FlowwersMonsters.";
        P6.gameObject.transform.localScale = new Vector3(1, 1, 1);
        P2.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P3.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P4.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P5.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        P1.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
}
