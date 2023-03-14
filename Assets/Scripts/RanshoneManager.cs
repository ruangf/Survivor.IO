using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanshoneManager : MonoBehaviour
{
    public GameObject RanshonePerf;
    public GameObject LocalisationFrom;
    public GameObject LocalisationRansh;



    void Start()
    {
        StartCoroutine(CheckPlace());
    }

    IEnumerator CheckPlace()
    {
        yield return new WaitForSeconds(2f);
        (Instantiate(RanshonePerf, LocalisationFrom.transform.position, LocalisationFrom.transform.rotation) as GameObject).transform.SetParent(LocalisationRansh.transform);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        (Instantiate(RanshonePerf, LocalisationFrom.transform.position, LocalisationFrom.transform.rotation) as GameObject).transform.SetParent(LocalisationRansh.transform);
        yield return new WaitForEndOfFrame();
        (Instantiate(RanshonePerf, LocalisationFrom.transform.position, LocalisationFrom.transform.rotation) as GameObject).transform.SetParent(LocalisationRansh.transform);
        yield return new WaitForEndOfFrame();
        (Instantiate(RanshonePerf, LocalisationFrom.transform.position, LocalisationFrom.transform.rotation) as GameObject).transform.SetParent(LocalisationRansh.transform);
        yield return new WaitForSeconds(5f);
        StartCoroutine(CheckPlace());
    }
}
