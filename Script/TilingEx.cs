/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//如果這個類沒有該物件(這裡為SpriteRenderer)就為此自動加入此物件(typeof之後再解釋)
[RequireComponent(typeof(SpriteRenderer))]

public class TilingEx : MonoBehaviour {

    #region Property


    #endregion

    #region Variables

    //X、Y軸的偏移量
    //偵測攝影機距離邊界的差距
    public float offset = 2;

    //該Sprite是否需要鏡射
    public bool reverseScale = false;

    /// <summary>
    ///     決定要由水平延伸或是垂直延伸
    ///     false = Horizontal  水平延伸 
    ///     true = Vertical 垂直延伸
    /// </summary>
    public bool horizontalOrVertical = false;

    //偵測上下左右是否已經生成Sprite
    private bool hasARightBuddy = false;
    private bool hasALeftBuddy = false;

    private bool hasATopBuddy = false;
    private bool hasABottomBuddy = false;

    //用來儲存Sprite的長度與寬度
    private float spriteWidth = 0f;
    private float spriteHeight = 0f;

    private Camera camera;
    private Transform myTransform;

    //決定該Sprite的鏡射數值
    private int rightOrTop = 1;
    private int leftOrBottom = -1;

    #endregion

    #region Unity Methods

    void Awake()
    {
        camera = Camera.main;

        //綁定此腳本物件的位置
        myTransform = transform;
    }

    void Start ()
	{
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteWidth = spriteRenderer.sprite.bounds.size.x;//訪問物件寬度
        spriteHeight = spriteRenderer.sprite.bounds.size.y;//訪問物件高度
    }
	

	void Update () 
	{
        BoundDetect();
    }
	
    void BoundDetect()
    {
        if (!horizontalOrVertical)
        {
            if(hasALeftBuddy == false || hasARightBuddy == false)
            {
                //calculate the camera extend (half the width) of what the camera can see in world coordinates
                //計算攝影機水平範圍的中心點延伸至邊界之距離 (畫面寬度的一半) "翻譯不完全請搭配原文服用"  //(內部)
                //攝影機正投影視點大小(該專案內部設定為15，依照個人使用者不同解析度也不同) * 螢幕寬度 / 螢幕高度 
                float camHorizontalExtend = camera.orthographicSize * Screen.width / Screen.height;

                //calculate the x position where the camera can see the edge of the sprite (element)
                //計算攝影機範圍邊界與Sprite(前景)x軸的座標差  //(外部)
                //攝影機右側可視範圍 = (MainCamera的X座標 + spriteWidth /2) - 攝影機水平範圍的中心點延伸至邊界之距離
                float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
                float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

                //checking if we can see the edge of the element and then calling MakeNewBuddy if we can
                //當攝影機的 x 軸座標 >= 攝影機右側可是邊界 - offsetX(用來控制攝影機邊界與Sprite的間隔) 和右側當前沒有Sprite生成時
                if (camera.transform.position.x >= edgeVisiblePositionRight - offset && hasARightBuddy == false)
                {
                    MakeNewBuddy(rightOrTop);
                    hasARightBuddy = true;
                }
                //與上面同理只是是針對左側
                else if (camera.transform.position.x <= edgeVisiblePositionLeft + offset && hasALeftBuddy == false)
                {
                    MakeNewBuddy(leftOrBottom);
                    hasALeftBuddy = true;
                }
            }
        }
        if (horizontalOrVertical)
        {
            if (hasATopBuddy == false || hasABottomBuddy == false)
            {
                //calculate the camera extend (half the width) of what the camera can see in world coordinates
                //計算攝影機垂直範圍的中心點延伸至邊界之距離 (畫面寬度的一半) "翻譯不完全請搭配原文服用"  //(內部)
                //攝影機正投影視點大小(該專案內部設定為15，依照個人使用者不同解析度也不同) * 螢幕高度 / 螢幕寬度 
                float camVerticalExtend = camera.orthographicSize * Screen.height / Screen.width;

                //calculate the x position where the camera can see the edge of the sprite (element)
                //計算攝影機範圍邊界與Sprite(前景)y軸的座標差  //(外部)
                //攝影機右側可視範圍 = (MainCamera的y座標 + spriteHeight /2) - 攝影機垂直範圍的中心點延伸至邊界之距離
                float edgeVisiblePositionTop = (myTransform.position.y + spriteHeight / 2) - camVerticalExtend;
                float edgeVisiblePositionBottom = (myTransform.position.y - spriteHeight / 2) + camVerticalExtend;

                if (camera.transform.position.y >= edgeVisiblePositionTop - offset && hasATopBuddy == false)
                {
                    MakeNewBuddy(rightOrTop);
                    hasATopBuddy = true;
                }
                //與上面同理只是是針對下面
                else if (camera.transform.position.y <= edgeVisiblePositionBottom + offset && hasABottomBuddy == false)
                {
                    MakeNewBuddy(leftOrBottom);
                    hasABottomBuddy = true;
                }
            }
        }
    }
    //right or left = 1 or -1
    //a function that creates a buddy on the side required
    void MakeNewBuddy(int direction)
    {
        if (!horizontalOrVertical)
        {
            //calculating the new position for our new buddy
            //計算新的座標給需要生成的Sprite
            Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * direction, myTransform.position.y, myTransform.position.z);

            //instantiating our new body and storing it in a variable
            //將再製的物件儲存至一個變數內，以方便調用
            Transform newBuddy = (Transform)Instantiate(myTransform, newPosition, myTransform.rotation);
            Debug.Log(newBuddy.name);

            //將新生成的物件鏡射(x軸的scale * -1)，在"平鋪"重複的背景的時候，鏡射之後再拼貼較不容易看到縫線以及破綻
            if (reverseScale == true)
            {
                newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
            }

            newBuddy.parent = myTransform.parent;

            if (direction > 0)
            {
                newBuddy.GetComponent<TilingEx>().hasALeftBuddy = true;
            }
            else
            {
                newBuddy.GetComponent<TilingEx>().hasARightBuddy = true;

            }
        }
        if (horizontalOrVertical)
        {
            //calculating the new position for our new buddy
            //計算新的座標給需要生成的Sprite
            Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight * direction, myTransform.position.z);

            //instantiating our new body and storing it in a variable
            //將再製的物件儲存至一個變數內，以方便調用
            Transform newBuddy = (Transform)Instantiate(myTransform, newPosition, myTransform.rotation);
            Debug.Log(newBuddy.name);

            //將新生成的物件鏡射(x軸的scale * -1)，在"平鋪"重複的背景的時候，鏡射之後再拼貼較不容易看到縫線以及破綻
            if (reverseScale == true)
            {
                newBuddy.localScale = new Vector3(newBuddy.localScale.x,newBuddy.localScale.y * -1, newBuddy.localScale.z);
            }

            newBuddy.parent = myTransform.parent;

            if (direction > 0)
            {
                newBuddy.GetComponent<TilingEx>().hasABottomBuddy = true; 
            }
            else
            {
                newBuddy.GetComponent<TilingEx>().hasATopBuddy = true;

            }
        }
    }

	#endregion
}
