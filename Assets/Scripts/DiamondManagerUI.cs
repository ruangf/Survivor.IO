using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondManagerUI : MonoBehaviour
{
    public GameObject Manager;
    public Sprite Green;
    public Sprite Blue;
    public Sprite Red;

    internal int ValueColor;
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        ValueColor = Random.Range(0, 2);
        StartCoroutine(Dist());
    }
    void Update()
    {
        if(Manager.GetComponent<GameManager>().Spawner.enabled == true)
        {
            Destroy(this.gameObject);
        }
        if (ValueColor == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = Green;
        }
        if (ValueColor == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = Blue;
        }
        if (ValueColor == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = Red;
        }
        float VecY;
        VecY = -1;
        transform.position = new Vector3(transform.position.x, transform.position.y + VecY, transform.position.z);
        transform.Rotate(0, 0, +2);
    }
    IEnumerator Dist()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
