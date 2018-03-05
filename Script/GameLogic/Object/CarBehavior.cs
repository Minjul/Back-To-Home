/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {

    #region Variables

    Rigidbody2D rb2d;

    public float carSpeed = 10f;
    #endregion

    #region Unity Methods

    void Start ()
	{
        rb2d = GetComponent<Rigidbody2D>();
	}
	

	void Update () 
	{
        Move();
    }

    void Move()
    {
        if(transform.localScale.x == 1)
        {
            rb2d.velocity = new Vector2(carSpeed, rb2d.velocity.y);
        }
        if (transform.localScale.x == -1)
        {
            rb2d.velocity = new Vector2(carSpeed*-1, rb2d.velocity.y);
        }

    }
	
	#endregion
}
