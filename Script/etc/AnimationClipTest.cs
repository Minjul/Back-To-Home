/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClipTest : MonoBehaviour{

    #region Variables

    Animator anim;

	#endregion
	
	#region Unity Methods
	
	void Start () 
	{
        anim = GetComponent<Animator>();

    }
	

	void Update () 
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizontal);
        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            Debug.Log("Try to walk");
            anim.SetInteger("Walk", 1);
        }
        else
        {
            Debug.Log("Try to stand");
            anim.SetInteger("Walk", 0);
        }
        //Debug.Log(horizontal);
	}
	
	#endregion
}
