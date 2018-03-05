/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    public static EventController instance;

    #region Property
    public bool CameraMove { get; set; }
    public bool GameStart { get; set; }
    public bool GamePause { get; set; }
    public bool PlayerControl { get; set; }
    public bool StartCutScene { get; set; }
    #endregion

    #region Variables

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one Event Controller");
            return;
        }
        instance = this;
    }

    #endregion
}
