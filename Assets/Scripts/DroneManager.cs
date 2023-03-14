using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Rocket;
    public GameObject Manager;
    public GameObject SpawenLocalisation;
   

    internal bool StartRocket = false;
    internal bool SpawenManager = true;
    internal bool SpawenManagers = true;
    internal bool CheckNormal = false;

    internal Vector3 Vec;

    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, 2.8f * Time.deltaTime);
        this.gameObject.GetComponent<SpriteRenderer>().flipX = Player.transform.position.x < this.transform.position.x;
        if (Manager.GetComponent<GameManager>().EnemyAvailable == true)
        {
            StartRocket = true;
            if(SpawenManager == true)
            {
                CheckNormal = true;
                StartCoroutine(SpawenRocket());
                SpawenManager = false;
            }
        }
        if (Manager.GetComponent<GameManager>().EnemyAvailable == false)
        {
            StartRocket = true;
            if (SpawenManagers == true)
            {
                CheckNormal = false;
                StartCoroutine(SpawenRocket());
                SpawenManagers = false;
            }
        }
    }
    IEnumerator SpawenRocket()
    {
        if(StartRocket == true)
        {
            yield return new WaitForEndOfFrame();
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(0.15f);
            (Instantiate(Rocket, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenLocalisation.transform);
            yield return new WaitForSeconds(1f);
            StartCoroutine(SpawenRocket());
        }
    }
}
