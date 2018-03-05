/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    #region Variables
    Animator anim;

    #endregion
	
	#region Unity Methods

	void Start ()
	{
        anim = GetComponentInChildren<Animator>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetInteger("Push", 1);
        }
    }


    #endregion
}
