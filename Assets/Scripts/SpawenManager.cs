using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawenManager : MonoBehaviour
{
    [Header("Spawener Managers")]
    public UIManager UI;
    public GameManager Managers;

    [Header("Enemys Manager")]
    public GameObject Zombie;

    [Header("Spawents Poins")]
    public GameObject SpawenLocalisation;
    public GameObject Spawen1;
    public GameObject Spawen2;
    public GameObject Spawen3;
    public GameObject Spawen4;

    [Header("Boolean Manager")]
    internal bool SpawenPos1 = false;
    internal bool SpawenPos2 = false;
    internal bool SpawenPos3 = false;
    internal bool SpawenPos4 = false;
    internal bool ManagerPose = false;
    internal bool MakeIt = false;
    [Header("Vectors Controller")]
    internal Vector3 Pos;

    void OnEnable()
    {
        StartCoroutine(SpaweningManager());
        StartCoroutine(stopSpawning());
    }
    void Update()
    {

            MakeIt = true;
    }
    public  IEnumerator stopSpawning()
    {
        yield return new WaitForEndOfFrame();
        if(MakeIt == true)
        {
            yield return new WaitForSeconds(1f);
            ManagerPose = true;
            yield return new WaitForSeconds(10f);
            ManagerPose = false;
            StartCoroutine(SpaweningManager());
        }
        StartCoroutine(stopSpawning());
    }

    public IEnumerator SpaweningManager()
    {
        yield return new WaitForEndOfFrame();
        if (ManagerPose == false)
        {
            if(MakeIt == true)
            {
                (Instantiate(Zombie, new Vector3(Spawen1.transform.position.x, Spawen1.transform.position.y + Random.Range(-5, 5), Spawen1.transform.position.z), Spawen1.transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
                (Instantiate(Zombie, new Vector3(Spawen2.transform.position.x + Random.Range(-5, 5), Spawen2.transform.position.y, Spawen2.transform.position.z), Spawen2.transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
                yield return new WaitForSeconds(0.9f);
            }
            StartCoroutine(SpaweningManager());
        }
    }
}
