using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.VFX;

public class JoystickManager : MonoBehaviour
{
    [Header("Manager Controller")]
    public GameManager Manager;
    public BooleanManager Boolean;
    public AudioManager Sounds;

    [Header("ManagerPlayer")]
    public movementJoystick joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    public GameObject Gun;

    [Header("Boolean Manager")]
    internal bool GameStarting = false;
    internal bool rigidManager = true;

    [Header("Animations")]
    public Animator anim;

    void Start()
    {
            
    }

    void Update()
    {
        if (Boolean.GameStart == true)
        {
            GameStarting = true;
            if(rigidManager == true)
            {
                rb = GetComponent<Rigidbody2D>();
                rigidManager = false;
            }
        }
        if(GameStarting == true)
        {
            if (rb.velocity.magnitude > 0)
            {
                anim.Play("CharacterBody");
            }
            else
            {
                anim.Play("0");
            }
            AnimatorController();
            if (joystickMovement.joystickVec.y != 0)
            {
                rb.velocity = new Vector2(joystickMovement.joystickVec.x * playerSpeed, joystickMovement.joystickVec.y * playerSpeed);

            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        if(Boolean.GameStart == false)
        {
            GameStarting = false;
            rigidManager = true;
        }
    }

    void AnimatorController()
    {
            if (joystickMovement.joystickVec.y < 0)
            {
                //Debug.Log("Going Down");
            }

            if (joystickMovement.joystickVec.y > 0)
            {
                //Debug.Log("Going Up");
            }

            if (joystickMovement.joystickVec.x < 0)
            {
                //Debug.Log(" Going Left");
                this.gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                if (Gun.activeSelf == true)
                {
                    Gun.transform.localScale = new Vector3(-0.2446888f, 0.2446888f, 0.2446888f);
                }
            }

            if (joystickMovement.joystickVec.x > 0)
            {
                //Debug.Log("Going Right");
                this.gameObject.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                if (Gun.activeSelf == true)
                {
                    Gun.transform.localScale = new Vector3(0.2446888f, 0.2446888f, 0.2446888f);
                }
            }
    }
}
