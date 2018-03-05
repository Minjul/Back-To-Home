/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    #region Property


    #endregion

    #region Variables
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(1f,3f)]
    public float pitch;

    public bool loop;

    [Range(0f, 1f)]
    public float spatialBlend;

    [HideInInspector]
    public AudioSource source;
    #endregion

    #region Unity Methods


    #endregion
}
