using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundClick : MonoBehaviour
{
    public GameObject Sound;
    public float Value = 1;
    void Update()
    {
        if(Sound.activeSelf == true)
        {
            GetComponent<AudioSource>().volume = Value;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
