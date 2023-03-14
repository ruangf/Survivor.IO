using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedGreen : MonoBehaviour
{
    public GameObject Rotatore;
    public GameObject Points;
    internal bool UpdateFixe = false;
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(0.4f);
        if (UpdateFixe == false)
        {
            (Instantiate(Rotatore, transform.position, transform.rotation) as GameObject).transform.SetParent(Points.transform);

        }
        StartCoroutine(Spawning());
    }
}
