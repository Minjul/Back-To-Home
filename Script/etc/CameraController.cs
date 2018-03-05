/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Variables

    LogicTestGM logicTestGM;

    public float moveSpeed;

    #endregion
	
	#region Unity Methods

	void Awake ()
	{
        logicTestGM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<LogicTestGM>();
    }
	

	void Update () 
	{
        if (logicTestGM.DeveloperMod)
        {
            CameraPositionControl();
        }
	}

    void CameraPositionControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0 || horizontal < 0)
        {
            transform.position = new Vector3(transform.position.x + horizontal * moveSpeed, transform.position.y, transform.position.z);

        }
        if (vertical > 0 || vertical < 0)
        {
            transform.position = new Vector3(transform.position.x, vertical * moveSpeed + transform.position.y, transform.position.z);
        }
    }
	
	#endregion
}
