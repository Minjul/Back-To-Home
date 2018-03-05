/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameMaster : MonoBehaviour {

    #region Variables
    private bool startMove = false;
    public bool StartMove
    {
        get
        {
            return startMove;
        }
        set
        {
            startMove = value;
        }
    }
    private bool showResult = false;
    public bool ShowResult
    {
        get
        {
            return showResult;
        }
        set
        {
            showResult = value;
        }
    }

    private bool gameStart = false;
    public bool GameStart
    {
        get
        {
            return gameStart;
        }
        set
        {
            gameStart = value;
        }
    }

    private bool isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
        }
    }

    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public Transform startFollow;
    public float waitSecond = 1.5f;
    public float gameTime;
    float waitTime;

    #endregion

    #region Unity Methods
	
	void Update () 
	{
        if (Input.GetKey(KeyCode.Space))
        {
            startMove = true;
        }

        if (GameObject.FindGameObjectWithTag("Player").transform.position.x >= startFollow.position.x)
        {
            gameStart = true;
        }

        if (!isGameOver)
        {
            Timer();
        }
        else if (isGameOver)
        {
            gameTime = gameTime;
            GameOver();
        }
	}

    void GameOver()
    {
        //因為gameStart = false，gameTime停止刷新所以waitTime才追得上gameTime
        waitTime = gameTime + waitSecond;
        if (Time.time > waitTime)
        {
            Time.timeScale = 0;
            showResult = true;
            startMove = false;
            //Debug.Log("GameTimeStop");
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
    
    void Timer()
    {
        if (gameStart)
        {
            gameTime = Time.time;
            gameTime = (float)Math.Round(gameTime, 2);
        }
    }
    #endregion
}
