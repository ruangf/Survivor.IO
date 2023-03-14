using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformFace : MonoBehaviour
{
    public  float ValueX;
    public  float ValueY;
    void Update()
    {
        this.gameObject.GetComponent<RawImage>().uvRect = new Rect(this.GetComponent<RawImage>().uvRect.position + new Vector2(ValueX, ValueY) * Time.deltaTime, this.gameObject.GetComponent<RawImage>().uvRect.size);
    }
}
