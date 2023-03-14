using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanyRoute : MonoBehaviour
{
    public GameObject SpawenPoint;
    public GameObject FireContainer;
    public GameObject Effect;
    public GameObject Fire;
    internal Vector3 Vec;
    private void Start()
    {
        SpawenPoint = GameObject.Find("PointFollowF");
        FireContainer = GameObject.Find("FireContainer");
        Effect = GameObject.Find("GaseBloomb");
        Vec = SpawenPoint.transform.position;
    }

    void Update()
    {
        transform.Rotate(0, 0, +3f);
        transform.position = Vector2.MoveTowards(this.transform.position, Vec, 3 * Time.deltaTime);
        if (transform.position == Vec)
        {
            (Instantiate(Fire, transform.position , Fire.transform.rotation) as GameObject).transform.SetParent(FireContainer.transform);
            Effect.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
