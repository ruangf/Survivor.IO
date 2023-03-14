using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Managers")]
    public BooleanManager BoolM;

    [Header("Componenet Sounds")]
    public GameObject Sound;
    public GameObject Music;
    public GameObject Vibration;

    void Update()
    {
        if(BoolM.Sound == true)
        {
            Sound.SetActive(true);
        }
        else
        {
            Sound.SetActive(false);
        }
        if(BoolM.Music == true)
        {
            Music.SetActive(true);
        }
        else
        {
            Music.SetActive(false);
        }
        if(BoolM.Vibration == true)
        {
            Vibration.SetActive(true);
        }
        else
        {
            Vibration.SetActive(false);
        }
    }
}
