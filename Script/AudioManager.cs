/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Property


    #endregion

    #region Variables

    public Sound[] sounds;

    #endregion

    #region Unity Methods

    public static AudioManager instance;

    void Awake ()
	{
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            //這裡的source為Sound類裡面所載入的AudioSource組件
            s.source = gameObject.AddComponent<AudioSource>();

            //將AudioSource裡面的屬性，與自建的Sound類中的變數做連結
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
	}
	
    public void Play(string name)
    {
        //陣列.Find(要搜尋的陣列名稱,Predicate<T>)
        //Predicate<T>為一個可以自定義的準則方法，並判斷是否符合此自定義的準則
        //這裡所自定義的準則為當前sound類裡面的name變數是否與將要指定使用(撥放)的物件(Clip)名稱相同
        //如果在陣列中找到名稱相同的物件(Clip)則程式繼續

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Unable to find Sound: " + name);
            return;
        }
        s.source.Play();
    }
	
	#endregion
}
