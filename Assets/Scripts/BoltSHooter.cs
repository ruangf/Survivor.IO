using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSHooter : MonoBehaviour
{
    [Header("Manager")]
    public GameObject Manager;

    [Header("Pefabes Manager")]
    public GameObject Diamond;
    public GameObject DiamondPos;
    public GameObject UImanager;

    [Header("Boolean Manager")]
    internal bool EnemyDispo = true;
    internal bool SpawenHire = true;
    internal bool CheckingList = true;

    [Header("Floating Manager")]
    internal int SpawenPoint;

    void Awake()
    {
        Manager = GameObject.Find("GameManager");
        DiamondPos = GameObject.Find("DiamondPos");
        UImanager = GameObject.Find("UI");
        CheckDestroy();
    }
    void Start()
    {

        StartCoroutine(ItemSelfDest());
    }

    void Update()
    {
        CheckDestroy();
        if(EnemyDispo == true)
        {
           transform.position = Vector2.MoveTowards(this.transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position, 10f * Time.deltaTime);
           Vector2 direction = GameObject.FindGameObjectWithTag("Enemy").transform.position - transform.position;
           float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
        }
        if(EnemyDispo == false)
        {
            if(CheckingList == true)
            {
                SpawenPoint = Random.Range(1, 16);
                CheckingList = false;
            }
            CheckPlaceSpawening();
        }
        if (UImanager.GetComponent<UIManager>().DestroyEnemys == true)
        {
            Destroy(this.gameObject);
        }
    }
    void CheckPause()
    {
 
    }
    void CheckPlaceSpawening()
    {
        if (SpawenPoint == 1 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos1").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos1").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos1").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }

        }
        if (SpawenPoint == 2 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos2").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos2").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos2").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 3 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos3").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos3").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos3").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 4 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos4").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos4").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos4").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 5 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos5").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos5").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos5").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 6 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos6").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos6").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos6").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 7 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos7").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos7").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos7").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 8 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos8").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos8").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos8").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 9 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos9").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos9").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos9").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 10 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos10").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos10").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos10").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 11 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos11").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos11").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos11").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 12 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos12").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos12").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos12").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 13 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos13").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos13").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos13").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 14 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos14").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos14").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos14").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 15 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos15").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos15").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos15").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 16 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos16").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos16").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos16").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
        if (SpawenPoint == 17 && SpawenHire == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.Find("Pos17").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.Find("Pos17").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
            CheckPause();
            if (transform.position == GameObject.Find("Pos17").transform.position)
            {
                (Instantiate(Diamond, transform.position, Diamond.transform.rotation) as GameObject).transform.SetParent(DiamondPos.transform);
                Destroy(this.gameObject);
            }
        }
    }
    void CheckDestroy()
    {
        if(Manager.GetComponent<GameManager>().NormalBolt == true)
        {
            EnemyDispo = true;
            StartCoroutine(NormalBolt());
        }
        if(Manager.GetComponent<GameManager>().DiamondBolt == true)
        {
            EnemyDispo = false;
            StartCoroutine(DiamondsBolt());
        }
    }

    IEnumerator NormalBolt()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    IEnumerator DiamondsBolt()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(Diamond, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    IEnumerator ItemSelfDest()
    {
        if(Manager.GetComponent<GameManager>().NormalBolt == true)
        {
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
