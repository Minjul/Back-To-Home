/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    #region Property



    #endregion

    #region Variables



    #endregion

    #region Unity Methods

    public static GameMaster instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start ()
	{

    }
	
	void Update () 
	{
        AudioTest();
    }

    void AudioTest()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindObjectOfType<AudioManager>().Play("train");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FindObjectOfType<AudioManager>().Play("car passing1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FindObjectOfType<AudioManager>().Play("car passing2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FindObjectOfType<AudioManager>().Play("car passing3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FindObjectOfType<AudioManager>().Play("car passing4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            FindObjectOfType<AudioManager>().Play("car horn");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            FindObjectOfType<AudioManager>().Play("Bug");
        }
    }
	#endregion
}
