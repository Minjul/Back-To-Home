/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    #region Variables

    Animator animator;
    PlayerControllerMouseVer playerControllerMouse;

    #endregion

    #region Unity Methods

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerControllerMouse = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerMouseVer>();
    }

    private void Update()
    {
        SleepAnim();
        Movement();
    }
    private void Movement()
    {
        if (playerControllerMouse.IsMoving)
        {
            animator.SetInteger("Walk", 1);
        }
        if (!playerControllerMouse.IsMoving)
        {
            animator.SetInteger("Walk", 0);
        }
    }
    private void SleepAnim()
    {

    }


    #endregion
}
