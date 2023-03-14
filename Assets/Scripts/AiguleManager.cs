using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiguleManager : MonoBehaviour
{
    public GameObject Aigule;
    public GameObject ContainerAigule;

    private void Start()
    {
        StartCoroutine(CheckSpose());
    }
    IEnumerator CheckSpose()
    {
        yield return new WaitForSeconds(1f);
        (Instantiate(Aigule, transform.position, transform.rotation) as GameObject).transform.SetParent(ContainerAigule.transform);
        yield return new WaitForSeconds(10f);
        StartCoroutine(CheckSpose());
    }
}
