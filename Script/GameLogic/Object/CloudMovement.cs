/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    #region Variables

    public float floatSpeed;
    Rigidbody2D rb2d;
    //Vector2 cloudPosition;

    #endregion

    #region Unity Methods
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        cloudFloat();
    }

    void cloudFloat()
    {
        //cloudPosition.x += floatSpeed;
        //transform.position = new Vector2(transform.position.x + floatSpeed, transform.position.y);
        rb2d.velocity = new Vector2(floatSpeed, rb2d.velocity.y);
    }
    #endregion
}
