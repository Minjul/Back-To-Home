/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAlpha : MonoBehaviour {

    #region Variables

    public float alphaSpeed = 0.01f;
    public float sec = 5f;
    public bool isFullAlpha = false;

    private Image image;
    private float currentTime;
    
    private Color theColor;
    

    #endregion

    #region Unity Methods

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start () 
	{
        theColor = image.color;
    }
	

	void Update () 
	{
        
        if (!isFullAlpha)
        {
            AddAlpha();
        }

        if (isFullAlpha)
        {
            Timer();
        }
    }

    private void AddAlpha()
    {
        //Debug.Log("Enter Add Alpha");

        theColor.a += alphaSpeed;
        image.color = theColor;
        //Debug.Log("this is in the addalpha" + image.color.a);

        if (theColor.a >= 1) //因為 > 1 為 true 所以會一直+0.01 -0.01
        {
            isFullAlpha = true;
        }

    }

    private void LessAlpha()
    {
        //Debug.Log("Enter Less Alpha");
        theColor.a -= alphaSpeed;
        image.color = theColor;
        //Debug.Log(image.color.a);
        if(theColor.a <= 0)   //todo 因為前面的UI存在的關係所以無法點到按鈕，需要優化並Disable
        {
            this.gameObject.SetActive(false);
        }
        
        //if (theColor.a <= 0)
        //{
        //    isFullAlpha = false;
        //}
    }
    private void Timer()
    {
        currentTime = Time.time;
        if (currentTime >= sec)
        {
            LessAlpha();
        }
    }

    #endregion
}
