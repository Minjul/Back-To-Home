/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameUI : MonoBehaviour {

    #region Variables
    MiniGameMaster miniGameMaster;

    #endregion
    public GameObject startPanel;
    public GameObject recordPanel;
    public GameObject restartPanel;

    float waitTime;
    float waitSecond;


    #region Unity Methods

    void Start ()
	{
        miniGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<MiniGameMaster>();
    }
	

	void Update () 
	{
        GameOverUI();

        if (miniGameMaster.StartMove)
        {
            startPanel.SetActive(false);
            recordPanel.SetActive(true);
        }
	}

    void GameOverUI()
    {
        if (miniGameMaster.IsGameOver && miniGameMaster.ShowResult)
        {
            startPanel.SetActive(true);
            restartPanel.SetActive(true);
            recordPanel.SetActive(false);
        }
    }
	
	#endregion
}
