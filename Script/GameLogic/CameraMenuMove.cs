/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuMove : MonoBehaviour {

    #region Property


    #endregion

    #region Variables

    Camera camera;

    public float speed = 0f;
    public float rotateAngle;

    public bool test = false;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        camera = Camera.main;
    }

    void Start ()
	{
        //speed /= 1000;
    }
	
	void Update () 
	{
        if (FindObjectOfType<EventController>().CameraMove)
        {
            Quaternion targetRotation = Quaternion.Euler(rotateAngle, transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            //不能直接使用transform.rotation.x 做比較，其值為四元數(約略為0.01~0.3之間)，不是我們一般常用的角度
            
            if (transform.rotation == targetRotation)
            {
                //Note FindObjectOfType<EventController>() 和 EventController.instance 的差異?
                FindObjectOfType<EventController>().StartCutScene = true;
            }
        }
    }
	#endregion
}
