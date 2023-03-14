using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerManager : MonoBehaviour
{
    [Header("Manager Controller")]
    public GameManager Manager;
    public BooleanManager Bool;


    [Header("Spawen Transformer")]
    public AudioSource EffectArrow;
    public AudioSource AudioHeat;
    public GameObject Death;
    public GameObject SpawenShoot;
    public GameObject ContainerWap;
    public Vector3 Offest;
    private Vector3 rb;

    [Header("Containers")]
    public GameObject Bolts;
    public GameObject UI;

    [Header("Boolean manager")]
    internal bool Deaths = true;


    void Start()
    {
        
    }
    void Update()
    {
        if(Bool.GameStart == true)
        {
            UI.transform.position = Vector3.SmoothDamp(transform.position, transform.position + Offest, ref rb, 0);
            SpawenShoot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            HitBolts();
        }
        
        if(Manager.HealthBar.fillAmount == 0)
        {
            Death.SetActive(true);
        }
        else
        {
            Death.SetActive(false);
        }
    }
    void HitBolts()
    {
        if (Bool.GameStart == true)
        {
            if (Manager.AvailabelWeapon == true)
            {
                if (Manager.SpawnObject == true)
                {
                    (Instantiate(Bolts, SpawenShoot.transform.position, Quaternion.identity) as GameObject).transform.SetParent(ContainerWap.transform);
                    EffectArrow.Play();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Bool.GameStart == true)
        {
            if (other.CompareTag("Enemy"))
            {
                AudioHeat.Play();
                Manager.Health -= 0.5f;
            }
        }
    }

}
