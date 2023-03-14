using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDowenEffect : MonoBehaviour
{
    public GameObject Diamond;
    public GameObject DiamondRed;

    void Start()
    {
        StartCoroutine(SpaweningDiamonds());
    }
    void Update()
    {
        
    }
    IEnumerator SpaweningDiamonds()
    {
        yield return new WaitForEndOfFrame();
        (Instantiate(Diamond, new Vector3(transform.position.x  + (Random.Range(-490, 490)), transform.position.y , transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x  + (Random.Range(-490, 490)), transform.position.y , transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        (Instantiate(Diamond, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        (Instantiate(DiamondRed, new Vector3(transform.position.x + (Random.Range(-490, 490)), transform.position.y, transform.position.z), transform.rotation) as GameObject).transform.SetParent(transform);
        yield return new WaitForSeconds(0.09f);
        StartCoroutine(SpaweningDiamonds());
    }
}
