using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject Bricking;
    public GameObject LocalisationBrick;


    void Start()
    {
        StartCoroutine(SpaweningBrick());
    }
    IEnumerator SpaweningBrick()
    {
        yield return new WaitForSeconds(1f);
        (Instantiate(Bricking, transform.position, transform.rotation) as GameObject).transform.SetParent(LocalisationBrick.transform);
        yield return new WaitForSeconds(5f);
        StartCoroutine(SpaweningBrick());
    }
}
