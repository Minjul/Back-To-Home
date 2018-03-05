/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{

    #region Property


    #endregion

    #region Variables

    Animator animator;

    #endregion

    #region Unity Methods	

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update () 
	{
        if (FindObjectOfType<EventController>().GameStart)
        {

            if (Input.anyKey)
            {
                animator.SetInteger("unVisible", 1);
            }
        }
    }
	
	#endregion
}
