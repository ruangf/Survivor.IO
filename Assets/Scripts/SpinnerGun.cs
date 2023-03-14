using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerGun : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 0, -5.2f);
    }
}
