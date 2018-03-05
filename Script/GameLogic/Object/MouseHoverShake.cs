/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverShake : MonoBehaviour {

    #region Variables
    Animator anim;

    public bool canShake = true;

    bool canHover = true;

    #endregion
	
	#region Unity Methods

	void Start ()
	{
        anim = GetComponent<Animator>();
	}
	

    void OnMouseOver()
    {
        if (canShake)
        {
            if (canHover)
            {
                anim.SetInteger("Hover", 1);
                canHover = false;
                Debug.Log(canHover);
            }
        }

    }

    void AnimationEnd()
    {
        anim.SetInteger("Hover", 0);
    }

    void OnMouseExit()
    {
        if (canShake)
        {
            canHover = true;
            Debug.Log(canHover);
        }

    }

    #endregion
}
