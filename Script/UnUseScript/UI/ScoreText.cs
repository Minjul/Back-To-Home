/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    #region Variables
    MiniGameMaster miniGameMaster;
    Text scoreText;
    #endregion

    #region Unity Methods

    void Start ()
	{
        miniGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<MiniGameMaster>();
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + miniGameMaster.Score;
    }

    void Update()
    {
        SetScoreText();    
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + miniGameMaster.Score;
    }

    #endregion
}
