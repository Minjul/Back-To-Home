/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    #region Property


    #endregion

    #region Variables

    Animator anim;
    Rigidbody2D rb2d;
    public int AIType;
    public float moveSpeed;

    bool isWalking = false;
    bool isRunning = false;
    
    #endregion
	
	#region Unity Methods

	void Start ()
	{
        anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () 
	{
        AISwitcher(AIType);
    }

    private void FixedUpdate()
    {
        if (isWalking)
        {
            Walk();
        }
        if (isRunning)
        {
            Run();
        } 
    }

    void AISwitcher(int AIType)
    {
        switch (AIType)
        {
            case 0:
                AIIdle();
                return;
            case 1:
                AIWalk();
                return;
            case 2:
                AIRun();
                return;
            case 3:
                Debug.Log("AI now is talking to someone");
                return;
            case 4:
                Debug.Log("AI now is following someone");
                return;
            default:
                break;
        }
    }

    void AIIdle()
    {
        if(isRunning|| isWalking)
        {
            isWalking = false;
            isRunning = false;
        }

        anim.SetInteger("Walk", 0);
        anim.SetInteger("Run", 0);
    }

    void AITalk()
    {
        //AI now is Talking
    }

    void AIWalk()
    {
        anim.SetInteger("Run", 0);
        anim.SetInteger("Walk", 1);
        if (isRunning)
        {
            isRunning = false;
        }
        isWalking = true;
    }

    void AIRun()
    {
        anim.SetInteger("Walk", 0);
        anim.SetInteger("Run", 1);
        if (isWalking)
        {
            isWalking = false;
        }
        isRunning = true;
    }
    void Follow()
    {
        //AI now is Following someone;
    }
    void Walk()
    {
        //停止移動後Velocity不會歸0
        if (transform.localScale.x == 1)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else if (transform.localScale.x == -1)
        {
            rb2d.velocity = new Vector2(moveSpeed * -1f, rb2d.velocity.y);
        }
    }
    void Run()
    {
        if (transform.localScale.x == 1)
        {
            rb2d.velocity = new Vector2(moveSpeed * 1.5f, rb2d.velocity.y);
        }
        else if (transform.localScale.x == -1)
        {
            rb2d.velocity = new Vector2(moveSpeed * 1.5f * -1f, rb2d.velocity.y);
        }
    }

    #endregion
}
