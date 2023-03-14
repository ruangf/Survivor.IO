using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpriteWeapons : MonoBehaviour
{
    [Header("Weapons Container")]
    public GameObject ProtecteurGreen;
    public GameObject DroneA;
    public GameObject DroneB;
    public GameObject DroneC;
    public GameObject BrikWall;
    public GameObject Gun;
    public GameObject SprineA;
    public GameObject SprineB;
    public GameObject Ball;
    public GameObject SalsaRanshom;
    public GameObject FireGase;
    public GameObject Aguel;

    [Header("Controller GameObjects")]
    public GameObject DroneContainer;
    public GameObject DroneObjectsContainer;
    public GameObject SprineContainer;

    [Header("Drones Objects")]
    public GameObject DroneObjectA;
    public GameObject DroneObjectB;
    public GameObject DroneObjectC;

    [Header("WeaponsIcons")]
    public Sprite SProtecteurGreen;
    public Sprite SDroneA;
    public Sprite SDroneB;
    public Sprite SDroneC;
    public Sprite SBrikWall;
    public Sprite SGun;
    public Sprite SSprineA;
    public Sprite SSprineB;
    public Sprite SBall;
    public Sprite SSalsaRanshone;
    public Sprite SFireGase;
    public Sprite SAguel;

    [Header("NamesWeapons")]
    internal string NProtecteurGreen;
    internal string NDroneA;
    internal string NDroneB;
    internal string NDroneC;
    internal string NBrikeWall;
    internal string NGun;
    internal string NSprineA;
    internal string NSprineB;
    internal string NBall;
    internal string NSalsaRanshon;
    internal string NFireGase;
    internal string Naguel;

    [Header("DescritionWeapons")]
    internal string DProtecteurGreen;
    internal string DDroneA;
    internal string DDroneB;
    internal string DDroneC;
    internal string DBrikWall;
    internal string DGun;
    internal string DSprineA;
    internal string DSprineB;
    internal string DBall;
    internal string DSalsaRanshon;
    internal string DFireGase;
    internal string DAguel;

    void Start()
    {
        ManagerTexting();
    }
    void Update()
    {
        
    }
    public void DesactivateAll()
    {
        ProtecteurGreen.SetActive(false);
        DroneA.SetActive(false);
        DroneB.SetActive(false);
        DroneC.SetActive(false);
        BrikWall.SetActive(false);
        Gun.SetActive(false);
        SprineA.SetActive(false);
        SprineB.SetActive(false);
        Ball.SetActive(false);
        SalsaRanshom.SetActive(false);
        FireGase.SetActive(false);
        Aguel.SetActive(false);
        DroneObjectA.SetActive(false);
        DroneObjectB.SetActive(false);
        DroneObjectC.SetActive(false);
        DroneContainer.SetActive(false);
        DroneObjectsContainer.SetActive(false);
        SprineContainer.SetActive(false);
    }
    public void Onaguel()
    {
        Aguel.SetActive(true);
    }
    public void OnFireGase()
    {
        FireGase.SetActive(true);
    }
    public void OnSalsaRanshon()
    {
        SalsaRanshom.SetActive(true);
    }
    public void OnBall()
    {
        Ball.SetActive(true);
    }
    public void OnSprineB()
    {
        SprineContainer.SetActive(true);
        SprineB.SetActive(true);
    }
    public void OnSprineA()
    {
        SprineContainer.SetActive(true);
        SprineA.SetActive(true);
    }
    public void OnGun()
    {
        Gun.SetActive(true);
    }
    public void OnProtecteurGreen()
    {
        ProtecteurGreen.SetActive(true);
    }
    public void OnBrikWall()
    {
        BrikWall.SetActive(true);
    }
    public void OnDroneA()
    {
        DroneContainer.SetActive(true);
        DroneObjectsContainer.SetActive(true);
        DroneObjectA.SetActive(true);
        DroneA.SetActive(true);
    }
    public void OnDroneB()
    {
        DroneContainer.SetActive(true);
        DroneObjectsContainer.SetActive(true);
        DroneObjectB.SetActive(true);
        DroneB.SetActive(true);
    }
    public void OnDroneC()
    {
        DroneContainer.SetActive(true);
        DroneObjectsContainer.SetActive(true);
        DroneObjectC.SetActive(true);
        DroneC.SetActive(true);
    }
    void ManagerTexting()
    {
        NProtecteurGreen = "Protecteur Zz";
        DProtecteurGreen = "This weapon Help you protect Your Self From Zombies thats Attac You";
        /////
        NDroneA = "Drone Monster";
        DDroneA = "This Drone Help You Attace Enemys with bolt";
        /////
        NDroneB = "Drone Electricaly";
        DDroneB = "This Drone Make Other Drones If Available With Multie Shoootings";
        /////
        NDroneC = "Drone Magicaly";
        DDroneC = "This Drone Make Player Move Eays Beside Enemys By Killing Them";
        /////
        NBrikeWall = " Briking Wall";
        DBrikWall = "This Kill Enemys By Breking Them Fulledly";
        /////
        NGun = " M45-7A";
        DGun = " You Shoot Enemys By this Gun On HeadShoot Directly To KillThem With Six Bults";
        /////
        NSprineA = "Springing H1A";
        DSprineA = "Help You To Kill Enemys By Shooting Rotatly On Head";
        /////
        NSprineB = "Protecteur H1B";
        DSprineB = " Make Enemys Move Down By Touching Them With H1B";
        /////
        NBall = "Ball Fooot";
        DBall = " Footbal Ball Heating Heads Of Enemys To Destroy Them Infinitly";
        /////
        NSalsaRanshon = "Fire Cup";
        DSalsaRanshon = " Firing Enemys And Kill Them Exactly Wheen The Fire Exploded";
        /////
        NFireGase = "Fire Gase";
        DFireGase = "Fire Gase Firing Enets With 100% Hydroilcation Type Of Fires";
        ////
        Naguel = "Aguel";
        DAguel = " Aguel Like Firebale But wuth Arrow Shoting On Head with HeadShoot";
    }
}
