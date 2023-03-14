using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundSwipe : MonoBehaviour
{
    public AudioSource Swiping;
    public SelectMapManager Manager;

    [Header("BooleanManager")]
    internal bool Checl1 = true;
    internal bool Checl2 = true;
    internal bool Checl3 = true;
    internal bool Checl4 = true;
    internal bool Checl5 = true;
    internal bool Checl6 = true;

    void Update()
    {
        if(Manager.Title.text == "1.wild Streets" && Checl1 == true)
        {
            Swiping.Play();
            Checl2 = true;
            Checl3 = true;
            Checl4 = true;
            Checl5 = true;
            Checl6 = true;
            Checl1 = false;
        }
        if (Manager.Title.text == "2.Jungle War" && Checl2 == true)
        {
            Swiping.Play();
            Checl1 = true;
            Checl3 = true;
            Checl4 = true;
            Checl5 = true;
            Checl6 = true;
            Checl2 = false;
        }
        if (Manager.Title.text == "3.wild Road" && Checl3 == true)
        {
            Swiping.Play();
            Checl1 = true;
            Checl2 = true;
            Checl4 = true;
            Checl5 = true;
            Checl6 = true;
            Checl3 = false;
        }
        if (Manager.Title.text == "4.desert boombs" && Checl4 == true)
        {
            Swiping.Play();
            Checl1 = true;
            Checl2 = true;
            Checl3 = true;
            Checl5 = true;
            Checl6 = true;
            Checl4 = false;
        }
        if (Manager.Title.text == "5.Enemy Streets" && Checl5 == true)
        {
            Swiping.Play();
            Checl1 = true;
            Checl2 = true;
            Checl3 = true;
            Checl4 = true;
            Checl6 = true;
            Checl5 = false;
        }
        if (Manager.Title.text == "6.container  Soliders" && Checl6 == true)
        {
            Swiping.Play();
            Checl1 = true;
            Checl2 = true;
            Checl3 = true;
            Checl4 = true;
            Checl5 = true;
            Checl6 = false;
        }
    }
}
