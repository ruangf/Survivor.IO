using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickManager : MonoBehaviour
{
    public int ForceAdd;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * ForceAdd);
        StartCoroutine(Dist());
    }
    IEnumerator Dist()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
