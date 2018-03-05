/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Variables
    Animator anim;
    public float moveSpeed;
    public bool isFlip = false;

    #region MiniGameVariable
    //MiniGameMaster miniGameMaster;
    //public float fallMultiplier;
    //public float lowJimpMultiplier; //Floating point variable to store the player's movement speed.
    //public float jumpVelocity;
    //public bool onGround;

    #endregion

    Rigidbody2D rb2d;//Store a reference to the Rigidbody2D component required to use 2D Physics.

    #endregion

    #region Unity Methods

    void Awake()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //miniGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<MiniGameMaster>();
    }

    #region move by keybored
    
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            {
                rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);
                anim.SetInteger("Walk", 1);
                Flip(moveHorizontal);
            }
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }
        
        //if (Input.GetKeyDown(KeyCode.Z) && onGround)
        //{
        //    Jump();
        //}
    }
    private void Flip(float inputH)
    {
        Vector3 theScale = transform.localScale;

        if (inputH < 0)
        {
            theScale.x = -1;
            transform.localScale = theScale;
            //isFlip = true;
        }
        else if (inputH > 0)
        {
            theScale.x = 1;
            transform.localScale = theScale;
            //isFlip = false;
        }

    }
    //private void Jump()
    //{
    //    Debug.Log("Try to jump");

    //    rb2d.AddForce(new Vector2(0f, jumpForce));

    //    onGround = false;
    //}

    #endregion

    #region MiniGame
    /*
    void Update()
    {
        if (!miniGameMaster.IsGameOver)
        {
            if (miniGameMaster.StartMove)
            {
                if (Input.GetKeyDown(KeyCode.Space) && onGround)
                {
                    Jump();
                }
                ParkourMovement();
                Fall();
            }
        }
    }
    void ParkourMovement()
    {
        anim.SetInteger("Walk", 1);
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up * jumpVelocity;
        onGround = false;
        anim.SetInteger("Jump", 1);
    }
    void Fall()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJimpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("I'm on the ground");
            onGround = true;
            anim.SetInteger("Jump", 0);
        }
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Fall down");
            anim.SetInteger("Fall", 1);
            miniGameMaster.IsGameOver = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Point")
        {
            miniGameMaster.Score++;
            Destroy(other.gameObject);
        }
    }

    */
    #endregion

    #endregion
}
