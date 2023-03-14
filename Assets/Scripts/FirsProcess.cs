using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirsProcess : MonoBehaviour
{
    [Header("Managers")]
    public ProcessManagerment Management;

    [Header("GameObjects Done")]
    public GameObject Done1;
    public GameObject Done2;
    public GameObject Done3;

    [Header("GameObjestNotFinish")]
    public GameObject NotDone1;
    public GameObject NotDone2;
    public GameObject NotDone3;

    [Header("Btns")]
    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    [Header("Boolean Manager")]
    internal bool LevOneDone = false;
    internal bool LevTwoDone = false;
    internal bool LevThreeDone = false;
    internal bool LevOneFinish = false;
    internal bool LevTwoFinish = false;
    internal bool LevThreeFinish = false;
    void Start()
    {
        NotDone1.SetActive(false);
    }
    void Update()
    {
        if(LevOneDone == true)
        {
            Done1.SetActive(true);
            NotDone1.SetActive(false);
            Btn1.interactable = true;
        }
        if(LevTwoDone == false && LevOneDone == true)
        {
            NotDone2.SetActive(false);
            Btn2.interactable = true;
            Btn1.interactable = false;
        }
        if (LevTwoDone == true)
        {
            Done2.SetActive(true);
            NotDone2.SetActive(false);
            Btn2.interactable = true;
        }
        if(LevThreeDone == false && LevTwoDone == true)
        {
            NotDone3.SetActive(false);
            Btn3.interactable = true;
            Btn2.interactable = false;
        }
        if (LevThreeDone == true)
        {
            Done3.SetActive(true);
            NotDone3.SetActive(false);
            Btn3.interactable = true;
        }
    }
}
