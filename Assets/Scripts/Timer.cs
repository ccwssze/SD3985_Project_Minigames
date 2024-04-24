using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    public double timerIncrementValue;
    double startTime;
    public double timer = 90;
    ExitGames.Client.Photon.Hashtable CustomValue;

    public Text timerText;
    public static bool timerIsRunning = false;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            timerIsRunning = true;
            CustomValue.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomValue);
        }     
        else
        {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            timerIsRunning = true;
        }
    }
    void Update()
    {
        if (!timerIsRunning) return;

        timerIncrementValue = PhotonNetwork.Time - startTime;
        double remainingTime = timer - (timerIncrementValue % timer);

        if (timerIncrementValue >= timer)
        {
            timerIsRunning = false;
            remainingTime = 0;
        }

        DisplayTime((float)remainingTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
