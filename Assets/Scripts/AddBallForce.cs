using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBallForce : MonoBehaviour
{
    public GameObject Ball;
    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            if(Left == true)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(-transform.right * 500);
            }
            if (Right == true)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
            }
            if (Up == true)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(transform.up * 500);
            }
            if (Down == true)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(-transform.up * 500);
            }
        }
    }
}
