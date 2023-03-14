using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityManager : MonoBehaviour
{
    [Header("Component")]
    public GameObject Face;

    [Header("Position Localisation")]
    public GameObject Pos1;

    void Start()
    {
        StartCoroutine(SpaweningFaces());
    }
    void Update()
    {
        
    }
    IEnumerator SpaweningFaces()
    {
        yield return new WaitForSeconds(14f);
        (Instantiate(Face, Pos1.transform.position, transform.rotation) as GameObject).transform.SetParent(Pos1.transform);
        yield return new WaitForSeconds(80f);
        StartCoroutine(SpaweningFaces());
    }
}
