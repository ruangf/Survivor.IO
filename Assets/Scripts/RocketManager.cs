using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Explosion;
    public GameObject Manager;
    public GameObject SpawenrLocalisation;
    public GameObject[] SpawenPos;
    public GameObject Enemy;
    internal Vector3 PosDirect;

    internal bool CheckingPlaces = true;
    internal bool StartPos = false;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Manager = GameObject.Find("GameManager");
        SpawenrLocalisation = GameObject.Find("RocketContainer");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 10);
    }
    void Update()
    {
        if (Manager.GetComponent<GameManager>().EnemyAvailable == true)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            transform.position = Vector2.MoveTowards(this.transform.position, Enemy.transform.position, 8f * Time.deltaTime);
            Vector2 direction = Enemy.transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
        }
        if(Manager.GetComponent<GameManager>().EnemyAvailable == false && CheckingPlaces == true)
        {
            StartCoroutine(CheckingInactivePlace());
            CheckingPlaces = false;
        }
        if (Manager.GetComponent<GameManager>().EnemyAvailable == false && StartPos == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, PosDirect, 8f * Time.deltaTime);
            Vector2 direction = PosDirect - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            if (transform.position == PosDirect)
            {
                (Instantiate(Explosion, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenrLocalisation.transform);
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator CheckingInactivePlace()
    {
        yield return new WaitForEndOfFrame();
        SpawenPos = GameObject.FindGameObjectsWithTag("PosNulled");
        PosDirect = SpawenPos[Random.Range(0, SpawenPos.Length)].transform.position;
        StartPos = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            (Instantiate(Explosion, transform.position, transform.rotation) as GameObject).transform.SetParent(SpawenrLocalisation.transform);
            Destroy(this.gameObject);
        }
    }
}
