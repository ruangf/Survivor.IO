using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerManager : MonoBehaviour
{

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text timeTextScreenFinish;
    public Text BestTime;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        timeTextScreenFinish.text = timeText.text;
        BestTime.text = timeText.text;
        if (timerIsRunning)
        {
            if (timeRemaining > -1)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                //timeRemaining = 0;
                //timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

