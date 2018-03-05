/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    #region Variables

    [SerializeField]
    private bool gameIsPaused = false;

    public GameObject titleToDestory;
    public GameObject gameMenu;
    public bool GameIsPaused
    {
        get
        {
            return gameIsPaused;
        }
        set
        {
            gameIsPaused = value;
        }
    }

    #endregion

    #region Unity Methods
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
        }
    }

    public void Pause()
    {
        gameMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log("Game Pause");
    }

    public void Resume()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Game Resume");
    }

    public void changeScene(int sceneIndex)
    {
        Debug.Log("changeScene((int)Define.SceneName.uITest)");
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    #endregion
}
