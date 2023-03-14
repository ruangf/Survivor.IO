using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DiamondVip : MonoBehaviour
{
    public GameObject Player;
    public GameObject Manager;
    public GameObject UIManager;
    internal bool MoveOn = false;
    public bool Green = false;
    public bool WorkOn = true;
    internal int Checking;
    void Start()
    {
        StartCoroutine(FollowPlayer());
        Player = GameObject.FindGameObjectWithTag("Player");
        Manager = GameObject.Find("GameManager");
        UIManager = GameObject.Find("UI");
    }
    void Update()
    {
        Checking = Random.Range(0, 2);
        if (MoveOn == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, 10f * Time.deltaTime);
        }
        if(UIManager.GetComponent<UIManager>().MapReady == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator FollowPlayer()
    {
        if(WorkOn == true)
        {
            yield return new WaitForSeconds(3f);
            MoveOn = true;
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
    }
    IEnumerator FlashingLed()
    {
        yield return new WaitForEndOfFrame();
        Manager.GetComponent<GameManager>().FillingFlash.SetActive(true);
        yield return new WaitForSeconds(0.005f);
        Manager.GetComponent<GameManager>().FillingFlash.SetActive(false);
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Manager.GetComponent<GameManager>().ValureLevel += Checking;
            if(Green == true)
            {
                UIManager.GetComponent<ManagerMecanique>().GemsInt += 1;
                PlayerPrefs.SetInt("gems", UIManager.GetComponent<ManagerMecanique>().GemsInt);
            }
            StartCoroutine(FlashingLed());
        }
    }
}
