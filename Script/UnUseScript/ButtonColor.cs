/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour {

    #region Variables

    public float alphaSpeed = 0.01f;
    public GameObject disableObj;

    private Button button;
    private ColorBlock theColor;
    private float btnAlpha;
    private bool addAlpha = false;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        button = GetComponent<Button>();
        theColor = GetComponent<Button>().colors;
    }

    void Start()
    {
        btnAlpha = theColor.normalColor.a;
    }

    void Update()//todo 偵測當OpeningPanel disable的時候 + alpha值
    {
        if(disableObj == false)
        {
            Debug.Log(disableObj);
            addAlpha = true;
        }

        if(addAlpha)
        {
            AddBtnAlpha();
        }
    }

    private void AddBtnAlpha()
    {
        if(btnAlpha <= 0.35)
        {
            btnAlpha += alphaSpeed;
            theColor.normalColor = new Color(1f, 1f, 1f, btnAlpha);
            button.colors = theColor;
        }

    }
    //public void ButtonTransitionColors()
    //{


    //    theColor.pressedColor = new Color(1f, 1f, 1f, 0.25f);

        
    //    Debug.Log("Cliked");
    //}

    #endregion
}
