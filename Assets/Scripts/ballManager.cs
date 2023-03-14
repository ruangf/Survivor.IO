using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal Vector3 LastVeclocity;
    internal bool CheckPos = true;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(StopBall());
    }
    void Update()
    {
        LastVeclocity = rb.velocity;
        if(CheckPos == true)
        {
            rb.AddForce(transform.right * 2);
            //CheckPos = false;
        }
        transform.Rotate(0, 0, +5);
    }
    IEnumerator StopBall()
    {
        yield return new WaitForSeconds(0.5f);
       // CheckPos = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = LastVeclocity.magnitude;
        var direction = Vector3.Reflect(LastVeclocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
