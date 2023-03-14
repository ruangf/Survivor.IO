using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Header("Manager Player")]
    public GameObject Player;
    public AudioSource Audio;

    [Header("Localisation PosDeb")]
    public GameObject Pos0;
    public GameObject Pos1;
    public GameObject Pos2;
    public GameObject Pos3;
    public GameObject Pos4;
    public GameObject Pos5;

    [Header("Bullet Effect")]
    public GameObject Bullet0;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;

    [Header("Container")]
    public GameObject ContainerBolt;

    void Start()
    {
        StartCoroutine(SpaweningBolt());
    }
    void Update()
    {
        //transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, 100f * Time.deltaTime);
    }
    IEnumerator SpaweningBolt()
    {
        yield return new WaitForEndOfFrame();
        Audio.Play();
        (Instantiate(Bullet0, Pos0.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        (Instantiate(Bullet1, Pos1.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        (Instantiate(Bullet2, Pos2.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        (Instantiate(Bullet3, Pos3.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        (Instantiate(Bullet4, Pos4.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        (Instantiate(Bullet5, Pos5.transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerBolt.transform);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpaweningBolt());
    }
}
