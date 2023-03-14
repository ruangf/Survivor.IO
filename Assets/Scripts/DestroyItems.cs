using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    public float time = 0.3f;
    void Start()
    {
        StartCoroutine(destroy());
        transform.Rotate(0, 0, Random.Range(1,180));
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
