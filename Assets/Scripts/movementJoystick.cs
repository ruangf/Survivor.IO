using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.EventSystems.EventTrigger;

public class movementJoystick : MonoBehaviour
{
    public GameObject ArrowDirecteur;
    public GameObject Gun;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;


    void Update()
    {
        if(joystickVec.x == 0 && joystickVec.y == 0)
        {
            ArrowDirecteur.SetActive(false);
        }
        else
        {
            ArrowDirecteur.SetActive(true);
            ArrowDirecteur.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-joystickVec.x, joystickVec.y) * 180 / Mathf.PI);
        }
        if(Gun.activeSelf == true)
        {
            Gun.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-joystickVec.x, joystickVec.y) * 180 / Mathf.PI);
        }
    }
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragePos = pointerEventData.position;
        joystickVec = (dragePos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragePos, joystickTouchPos);
        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }
    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }



}
