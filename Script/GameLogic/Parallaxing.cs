/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    #region Variables

    public Transform[] backgrounds;//Array (list) of all the back - and foreground to be parallaxed.
                                   //(用來存取前景與背景，陣列儲存)

    public float smoothing;        //How smooth the parallax is going to be. Make sure to set this above 0.
                                   //調整視差的平滑度，注意：此變數值必須大於 0

    private float[] paralaxScales; //The proportion of the camera's movement to move the background by.
                                   //依照比例，按攝影機移動的座標，調整背景。 陣列儲存
                                   //存取的內容也就是背景的座標位置

    private Transform cam;
    private Vector3 previousCamPos;// The position of the camera in the previous frame.
                                   //存取攝影機在前一幀的位置

    #endregion

    #region Unity Methods

    //Awake() Is called before Start(). Great for reference
    void Awake()
    {
        //set up the reference
        //將變數cam與MainCamera綁定(利用程式會在遊戲開始的時候直接幫我們綁定，不需要透過Unity 的UI)
        cam = Camera.main.transform;

    }

    void Start()
    {
        //The previous frame had the curret frame's camera position	
        previousCamPos = cam.position; //存取前一幀攝影機的所在位置

        // asigning coresponding parallaxScales 
        //註冊相對的"視差大小" <-(翻譯的很爛我知道)
        paralaxScales = new float[backgrounds.Length];//此陣列長度 = 背景以及前景的數量

        for (int i = 0; i < backgrounds.Length; i++)
        {
            //陣列paralaxScales裡面所存取的值 = 背(前)景的z座標 * -1，也就是說他所存取的是所有背(前)景座標位置的 Z 軸*-1
            paralaxScales[i] = backgrounds[i].position.z * -1;
        }

    }


    void Update()
    {
        //for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            //"視差" = (攝影機在前一幀 x 座標的位置 - 攝影機現在這一幀 x 座標的位置) * 背(前)景的當前位置
            //(攝影機在前一幀 x 座標的位置 - 攝影機現在這一幀 x 座標的位置) 其實就是攝影機在每一幀的移動量，利用這個值*背(前景)景位置讓背(前)景作視差移動
            float parallax = (previousCamPos.x - cam.position.x) * paralaxScales[i];

            // set a target x position which is the curret position plus the parallax
            //設置目標背(前)景的 x 座標 = 該座標原來 x 的位置加上"視差"的值
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the background's current position with it's target x position
            //將上面所計算出來的移動量存在一個新的三維向量變數，並賦予至其 X 值，Y跟Z使用原來背(前)景自己的座標
            //其三維變數(backgroundTargetPos) = 當前陣列存取到的背(前)景所要移動至的目標座標
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current position and the target position using Lerp
            //利用 Lerp 讓背(前)景可以平滑的移動到我們所指定的目標座標(如果不用Lerp會直接瞬移過去) 
            //"上面Brackeys的筆記所指的target就是背(前)景最終要移動至的目標座標"
            //Lerp(當前陣列所存取到的背(前)景物件座標，背景最終移動至的目標座標，smoothing * 電腦每秒幀數) <-利用smoothing變數來控制平滑值
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set the previousCamPos to the camera's position at the end of the frame
        //在當前幀數結束的時候將現在攝影機的變數值，存入前一次攝影機的變數值
        //這樣才可以不斷的更新攝影機以及背(前)景位置
        previousCamPos = cam.position;

    }

    #endregion
}
