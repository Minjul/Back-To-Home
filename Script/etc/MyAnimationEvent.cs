/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationEvent : MonoBehaviour
{

    #region Variables

    public GameObject startText;

    #endregion

    #region Unity Methods

    private void Start()
    {
        if(startText == null)
        {
            return;
        }
        
    }

    void startSign()
    {
        startText.SetActive(true);
    }
    void gameStart()
    {
        FindObjectOfType<EventController>().GameStart = true;
    }
    void cameraMove()
    {
        FindObjectOfType<EventController>().CameraMove = true;
    }

    void End()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    #endregion
}
