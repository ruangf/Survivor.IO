using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheckerPlayer : MonoBehaviour
{
    public GameObject UIManager;

    private void Start()
    {
        UIManager = GameObject.Find("UI");

    }
    private void Update()
    {
        if(UIManager.GetComponent<UIManager>().StopAllAudios == true)
        {
            Destroy(this.gameObject);
        }
    }
}
