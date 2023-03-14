using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPoint : MonoBehaviour
{
    public GameObject FollowPoint;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, FollowPoint.transform.position.y, transform.position.z);
    }
}
