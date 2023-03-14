using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS : MonoBehaviour
{
    [Header("Game Managers")]
    public GameManager Manager;

    [Header("Boolean Manager")]
    public bool GameStart = false;

    void Start()
    {
        
    }
    void Update()
    {
        Manager.GameStart = GameStart;
    }
}
