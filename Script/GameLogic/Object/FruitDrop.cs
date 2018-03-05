/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDrop : MonoBehaviour {

    #region Variables

    Animator anim;
    Rigidbody2D rb2d;
    Object obj;

    float dropGravity = 2f;
    int clickCounter = 0;
    int maxCount = 1;
    bool canHover = true;

    #endregion
	
	#region Unity Methods

	void Start ()
	{
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Debug.Log(canHover);
    }
	

	void Update () 
	{
        Fall();
    }

    void Fall()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (dropGravity - 1) * Time.deltaTime;
        }
    }

    void AnimationEnd()
    {
        anim.SetInteger("Shake", 0);
        clickCounter++;
        Debug.Log(clickCounter);
        if (clickCounter >= maxCount)
        {
            anim.SetInteger("Fall", 1);
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }

    void OnMouseOver()
    {
        Debug.Log("mouse hover");

        if (canHover)
        {
            anim.SetInteger("Shake", 1);
            canHover = false;
            Debug.Log(canHover);
        }
    }

    void OnMouseExit()
    {
        if (clickCounter < maxCount)
        {
            canHover = true;
            Debug.Log(canHover);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("I'm on the ground");
            obj = Resources.Load(Define.FruitBrake);
            Vector2 createPoint = new Vector2(transform.position.x, transform.position.y + 0.5f);
            GameObject newObject = Instantiate(obj, createPoint, transform.rotation) as GameObject;
            GameObject destroyObject = newObject;
            Destroy(newObject, 2f);
            Destroy(gameObject);
        }
    }
    #endregion
}
