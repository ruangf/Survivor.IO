using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWeapons : MonoBehaviour
{
    public Image IconPlayer;
    public GameObject Weapon;
    private Button Btn;

    private void Start()
    {
        Weapon = gameObject.transform.Find("Icon").gameObject;
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(ChangePecture);
    }
    void ChangePecture()
    {
        IconPlayer.sprite = Weapon.GetComponent<Image>().sprite;
    }

}
