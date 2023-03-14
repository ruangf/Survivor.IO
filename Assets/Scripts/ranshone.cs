using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranshone : MonoBehaviour
{
    public GameObject SpawenPoint;
    public GameObject Fire;
    public GameObject Audio;
    internal Vector3 Vec;
    private void Start()
    {
        SpawenPoint = GameObject.Find("PointFollowF");
        Audio = GameObject.Find("Ransha");
        Vec = SpawenPoint.transform.position;
    }

    void Update()
    {
        transform.Rotate(0, 0, +3f);
        transform.position = Vector2.MoveTowards(this.transform.position, Vec, 3 * Time.deltaTime);
        if(transform.position == Vec)
        {
            Instantiate(Fire, transform.position, Fire.transform.rotation);
            Audio.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
