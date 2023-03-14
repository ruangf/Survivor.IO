using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spinner;
    public float SpeedMove;
    public Vector3 Offest;
    private Vector3 rb;
    internal bool Manage = true;

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + Offest, ref rb, SpeedMove);
    }
    void Update()
    {
        if(Spinner.activeSelf == true && Manage == true)
        {
            this.gameObject.GetComponent<Camera>().fieldOfView += 0.5f;
            if(this.gameObject.GetComponent<Camera>().fieldOfView == 85)
            {
                Manage = false;
            }
        }
    }
}
