using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorePoints : MonoBehaviour
{
    public float Value = 100;
    void Update()
    {
        transform.Rotate(0, 0, +Value);
    }
}
