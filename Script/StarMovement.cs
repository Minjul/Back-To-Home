/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour {

    #region Property


    #endregion

    #region Variables
    public float speed;
    Rigidbody2D rb2d;

    #endregion

    #region Unity Methods

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //speed /= 1000;    
    }

    void FixedUpdate () 
	{
        //transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
    }
	
	#endregion
}
