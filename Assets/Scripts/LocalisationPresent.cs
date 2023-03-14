using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationPresent : MonoBehaviour
{
    public GameObject UI;
    public GameObject ControllerSpawener;
    internal bool Check = false;

    private void Start()
    {
        ControllerSpawener = GameObject.Find("Camera");
        UI = GameObject.Find("UI");
        StartCoroutine(WaitingActive());
    }
    private void Update()
    {
        if(UI.GetComponent<UIManager>().MapReady == true && Check == true)
        {
            ControllerSpawener.GetComponent<ControllerSpawening>().SpawenOne.GetComponent<SpawenManager>().SpawenLocalisation = this.gameObject;
            ControllerSpawener.GetComponent<ControllerSpawening>().SpawenTwo.GetComponent<SpawenManager>().SpawenLocalisation = this.gameObject;
        }
    }
    IEnumerator WaitingActive()
    {
        yield return new WaitForEndOfFrame();
        Check = true;
    }
}
