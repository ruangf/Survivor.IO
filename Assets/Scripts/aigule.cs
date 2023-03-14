using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aigule : MonoBehaviour
{
    public GameObject manager;
    internal Rigidbody2D rb;
    internal Vector3 LastVeclocity;
    internal bool CheckPos = true;

    void Start()
    {
        manager = GameObject.Find("GameManager");
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(manager.GetComponent<GameManager>().EnemyAvailable == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position, 10f * Time.deltaTime);
            Vector2 direction = GameObject.FindGameObjectWithTag("Enemy").transform.position - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
