﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManagerInGame : MonoBehaviour
{
    public Text scorePlayer1;
    public Text scorePlayer2;
    public Text timeLeftText;
    public Text hasWonText;
    public BaseMovement Player1;
    public BaseMovement Player2;
    public float timeLeft = 3; 
    private string TimeLeftString;
    public GameObject InGameCanvasGameObject;
    public GameObject counting;
    public GameObject playing;
    public GameObject hasWon;
    void Update() {
        //health
        scorePlayer1.text = Player1.heath.ToString();
        scorePlayer2.text = Player2.heath.ToString();

        //count down
        if (timeLeft <= 0 && timeLeft >= -1 )
        {
            TimeLeftString = "Fight!";
            GameManager.Instance.state = GameManager.State.playing;
        } else if (timeLeft < -1) {
            TimeLeftString = "";
        } else {
            TimeLeftString = timeLeft.ToString("F1");
        }
        timeLeftText.text = TimeLeftString;
        timeLeft -= Time.deltaTime;
        counting.SetActive(GameManager.Instance.state == GameManager.State.counting || GameManager.Instance.state == GameManager.State.playing);
        playing.SetActive(GameManager.Instance.state == GameManager.State.playing || GameManager.Instance.state == GameManager.State.hasWon);
        hasWon.SetActive(GameManager.Instance.state == GameManager.State.hasWon);
        hasWonText.text = GameManager.Instance.hasWonString;
    }
}