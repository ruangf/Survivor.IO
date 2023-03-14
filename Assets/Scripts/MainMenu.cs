using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MSettings;
    public GameObject MMessages;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OpenSetting()
    {
        MSettings.SetActive(true);
    }
    public void OpenMessages()
    {
        MMessages.SetActive(true);
    }
    public void ExitSetting()
    {
        MSettings.SetActive(false);
    }
    public void ExitMessages()
    {
        MMessages.SetActive(false);
    }
}
