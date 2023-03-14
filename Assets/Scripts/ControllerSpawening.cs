using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSpawening : MonoBehaviour
{
    public GameObject Spawner;
    public UIManager Manager;public GameManager Managers;

    public GameObject SpawenOne;
    public GameObject SpawenTwo;
    internal bool CheckWork = true;
    internal bool KeepingGame = false;
    void Update()
    {
        if(KeepingGame == true)
        {
            Managers.ResumeBtn();
        }
        if(Manager.MapReady == false)
        {
            Spawner.SetActive(false);
            CheckWork = true;
        }
        if (Manager.MapReady == true)
        {
            Spawner.SetActive(true);
            if(CheckWork == true)
            {
                StartCoroutine(SpawenOne.GetComponent<SpawenManager>().SpaweningManager());
                StartCoroutine(SpawenTwo.GetComponent<SpawenManager>().SpaweningManager());
                StartCoroutine(SpawenOne.GetComponent<SpawenManager>().stopSpawning());
                StartCoroutine(SpawenTwo.GetComponent<SpawenManager>().stopSpawning());
                CheckWork = false;
            }
        }
    }
    public void StartGame()
    {
        KeepingGame = true;
    }
    public void StopPause()
    {
        KeepingGame = false;
    }
}
