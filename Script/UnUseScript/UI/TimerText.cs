/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

    #region Variables
    MiniGameMaster miniGameMaster;
    Text timerText;
    #endregion

    #region Unity Methods

    void Start()
    {
        miniGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<MiniGameMaster>();
        timerText = GetComponent<Text>();
    }
    void Update()
    {
        SetTimerText();    
    }

    void SetTimerText()
    {
        timerText.text = "Time: " + miniGameMaster.gameTime + "s";
    }

    #endregion
}
