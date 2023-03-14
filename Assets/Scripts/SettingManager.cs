using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [Header("Manager")]
    public BooleanManager BoolM;

    [Header("Sound")]
    public GameObject SActiveBtn;
    public GameObject SInactiveBtn;
    public GameObject SIconActive;
    public GameObject SIconInactive;

    [Header("Music")]
    public GameObject MActiveBtn;
    public GameObject MInactiveBtn;
    public GameObject MIconActive;
    public GameObject MIconInactive;

    [Header("Vibration")]
    public GameObject VActiveBtn;
    public GameObject VInactiveBtn;
    public GameObject VIconActive;
    public GameObject VIconInactive;


    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void SoundActive()
    {
        SActiveBtn.SetActive(true);
        SInactiveBtn.SetActive(false);
        SIconActive.SetActive(true);
        SIconInactive.SetActive(false);
        BoolM.Sound = true;
    }
    public void SoundInActive()
    {
        SActiveBtn.SetActive(false);
        SInactiveBtn.SetActive(true);
        SIconActive.SetActive(false);
        SIconInactive.SetActive(true);
        BoolM.Sound = false;
    }
    public void MusicActive()
    {
        MActiveBtn.SetActive(true);
        MInactiveBtn.SetActive(false);
        MIconActive.SetActive(true);
        MIconInactive.SetActive(false);
        BoolM.Music = true;
    }
    public void MusicInactiveActive()
    {
        MActiveBtn.SetActive(false);
        MInactiveBtn.SetActive(true);
        MIconActive.SetActive(false);
        MIconInactive.SetActive(true);
        BoolM.Music = false;
    }
    public void VibrationActive()
    {
        VActiveBtn.SetActive(true);
        VInactiveBtn.SetActive(false);
        VIconActive.SetActive(true);
        VIconInactive.SetActive(false);
        BoolM.Vibration = true;
    }
    public void VibrationInactiveActive()
    {
        VActiveBtn.SetActive(false);
        VInactiveBtn.SetActive(true);
        VIconActive.SetActive(false);
        VIconInactive.SetActive(true);
        BoolM.Vibration = false;
    }
}
