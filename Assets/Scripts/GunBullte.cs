using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullte : MonoBehaviour
{
    public GameObject FollowPoint;
    public bool Sec1;
    public bool Sec2;
    public bool Sec3;
    public bool Sec4;
    public bool Sec5;
    public bool Sec6;
    internal Vector3 Pos;

    void Start()
    {
        StartCoroutine(Destri());
        if (Sec1 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints0");
        }
        if (Sec2 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints1 ");
        }
        if (Sec3 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints2 ");
        }
        if (Sec4 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints3 ");
        }
        if (Sec5 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints4 ");
        }
        if (Sec6 == true)
        {
            FollowPoint = GameObject.Find("SpaweningPoints5");
        }
        Pos = FollowPoint.transform.position;
    }
    IEnumerator Destri()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Pos, 7f * Time.deltaTime);
        Vector2 direction = Pos - transform.position;
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.gameObject.GetComponent<Rigidbody2D>().rotation = Angle;

        if(transform.position == Pos)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
