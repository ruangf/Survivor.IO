using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessManagerment : MonoBehaviour
{
    [Header("Controller")]
    public Button Btn;

    [Header("Procesing Manager")]
    public FirsProcess M1;
    public FirsProcess M2;
    public FirsProcess M3;
    public FirsProcess M4;
    public FirsProcess M5;
    public FirsProcess M6;

    [Header("Floating Manager")]
    internal float ManagerTime = 0.5f;

    [Header("Managers Controller")]
    public LevelsManager Manager;

    void Start()
    {

    }
    void Update()
    {
        
    }
    public void OneLevel1()
    {
        Manager.Level1 = Manager.Levels[0];
        Btn.onClick.Invoke();
        StartCoroutine(CheckDoneOne());
    }
    IEnumerator CheckDoneOne()
    {
        yield return new WaitForSeconds(ManagerTime);
        M1.LevOneDone = true;
    }
    public void OneLevel2()
    {
        Manager.Level1 = Manager.Levels[0];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLevel2());
    }
    IEnumerator CheckLevel2()
    {
        yield return new WaitForSeconds(ManagerTime);
        M1.LevTwoDone = true;
    }
    public void OneLevel3()
    {
        Manager.Level1 = Manager.Levels[0];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLevelOneThree());
    }
    IEnumerator CheckLevelOneThree()
    {
        yield return new WaitForSeconds(ManagerTime);
        M1.LevThreeDone = true;
    }
    public void TwoLevel1()
    {
        Manager.Level1 = Manager.Levels[1];
        Btn.onClick.Invoke();
        StartCoroutine(CheckleevlTwoOne());
    }
    IEnumerator CheckleevlTwoOne()
    {
        yield return new WaitForSeconds(ManagerTime);
        M2.LevOneDone = true;
    }
    public void TwoLevel2()
    {
        Manager.Level1 = Manager.Levels[1];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLevTwo());
    }
    IEnumerator CheckLevTwo()
    {
        yield return new WaitForSeconds(ManagerTime);
        M2.LevTwoDone = true;
    }
    public void TwoLevel3()
    {
        Manager.Level1 = Manager.Levels[1];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLevelTwoThree());
    }
    IEnumerator CheckLevelTwoThree()
    {
        yield return new WaitForSeconds(ManagerTime);
        M2.LevThreeDone = true;
    }
    public void ThreeLevel1()
    {
        Manager.Level1 = Manager.Levels[2];
        Btn.onClick.Invoke();
        StartCoroutine(Lev3One());
    }
    IEnumerator Lev3One()
    {
        yield return new WaitForSeconds(ManagerTime);
        M3.LevOneDone = true;
    }
    public void ThreeLevel2()
    {
        Manager.Level1 = Manager.Levels[2];
        Btn.onClick.Invoke();
        StartCoroutine(Lev3Two());
    }
    IEnumerator Lev3Two()
    {
        yield return new WaitForSeconds(ManagerTime);
        M3.LevThreeDone = true;
    }
    public void ThreeLevel3()
    {
        Manager.Level1 = Manager.Levels[2];
        Btn.onClick.Invoke();
    }
    IEnumerator Lev3Three()
    {
        yield return new WaitForSeconds(ManagerTime);
        M3.LevThreeDone = true;
    }
    public void FourLevel1()
    {
        Manager.Level1 = Manager.Levels[3];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLev41());
    }
    IEnumerator CheckLev41()
    {
        yield return new WaitForSeconds(ManagerTime);
        M4.LevOneDone = true;
    }
    public void FourLevel2()
    {
        Manager.Level1 = Manager.Levels[3];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLev42());
    }
    IEnumerator CheckLev42()
    {
        yield return new WaitForSeconds(ManagerTime);
        M4.LevTwoDone = true;
    }
    public void FourLevel3()
    {
        Manager.Level1 = Manager.Levels[3];
        Btn.onClick.Invoke();
        StartCoroutine(CheckLev43());
    }
    IEnumerator CheckLev43()
    {
        yield return new WaitForSeconds(ManagerTime);
        M4.LevThreeDone = true;
    }
    public void FiveLevel1()
    {
        Manager.Level1 = Manager.Levels[4];
        Btn.onClick.Invoke();
        StartCoroutine(checkLev51());
    }
    IEnumerator checkLev51()
    {
        yield return new WaitForSeconds(ManagerTime);
        M5.LevOneDone = true;
    }
    public void FiveLevel2()
    {
        Manager.Level1 = Manager.Levels[4];
        Btn.onClick.Invoke();
        StartCoroutine(checkLev52());
    }
    IEnumerator checkLev52()
    {
        yield return new WaitForSeconds(ManagerTime);
        M5.LevTwoDone = true;
    }
    public void FiveLevel3()
    {
        Manager.Level1 = Manager.Levels[4];
        Btn.onClick.Invoke();
        StartCoroutine(checkLev53());
    }
    IEnumerator checkLev53()
    {
        yield return new WaitForSeconds(ManagerTime);
        M5.LevThreeDone = true;
    }
    public void SixLevel1()
    {
        Manager.Level1 = Manager.Levels[5];
        Btn.onClick.Invoke();
        StartCoroutine(check61());
    }
    IEnumerator check61()
    {
        yield return new WaitForSeconds(ManagerTime);
        M6.LevOneDone = true;
    }
    public void SixLevel2()
    {
        Manager.Level1 = Manager.Levels[5];
        Btn.onClick.Invoke();
        StartCoroutine(check62());
    }
    IEnumerator check62()
    {
        yield return new WaitForSeconds(ManagerTime);
        M6.LevTwoDone = true;
    }
    public void SixLevel3()
    {
        Manager.Level1 = Manager.Levels[5];
        Btn.onClick.Invoke();
        StartCoroutine(check63());
    }
    IEnumerator check63()
    {
        yield return new WaitForSeconds(ManagerTime);
        M6.LevThreeDone = true;
    }
}
