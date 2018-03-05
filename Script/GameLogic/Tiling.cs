/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//如果這個類沒有該物件(這裡為SpriteRenderer)就為此自動加入此物件(typeof之後再解釋)
[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    #region Variables
    public Transform recyclePoint;

    //the offset so that we don't get any weird errors
    // X 軸的偏移量
    //用來偵測攝影機距離前景邊界的差距 
    public int offsetX = 2;

    //these are used for checking if we need to instantiate stuff
    //偵測左(右)測是否已經生成了前景
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    //used if the object is not tilable
    //不知道怎翻譯，看下面功能在上來補充 (字面義：當物件無法"平鋪"時使用此變數)    
    // 2017/10/31新增註釋：這個變數是用來鏡射物件用的，2D平面背景在做平鋪的時候，鏡射後再拼貼比較不會有瑕疵
    public bool reverseScale = false;

    //public Transform parents;

    //the width of our element
    //檢測該Sprite 的寬度
    private float spriteWidth = 0f;

    private Camera cam;
    private Transform myTransform;
    private int right = 1;
    private int left = -1;

    #endregion

    #region Unity Methods

    void Awake()
    {
        cam = Camera.main;

        //綁定此腳本物件的位置
        myTransform = transform;
    }

    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();

        spriteWidth = sRenderer.sprite.bounds.size.x; //用來訪問該物件的寬度

    }


    void Update()
    {
        Recycle();
        // does it still need buddies? If not do nothing (If it's "true" do nothing)
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            //calculate the camera extend (half the width) of what the camera can see in world coordinates
            //計算攝影機水平範圍的中心點延伸至邊界之距離 (畫面寬度的一半) "翻譯不完全請搭配原文服用"  //(內部)
            //攝影機正投影視點大小(該專案內部設定為15，依照個人使用者不同解析度也不同) * 螢幕寬度 / 螢幕高度 
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            //calculate the x position where the camera can see the edge of the sprite (element)
            //計算攝影機範圍邊界與Sprite(前景)x軸的座標差  //(外部)
            //攝影機右側可視範圍 = (MainCamera的X座標 + spriteWidth /2) - 攝影機水平範圍的中心點延伸至邊界之距離
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            //checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            //當攝影機的 x 軸座標 >= 攝影機右側可是邊界 - offsetX(用來控制攝影機邊界與Sprite的間隔) 和右側當前沒有Sprite生成時
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(right);
                hasARightBuddy = true;
            }
            //與上面同理只是是針對左側
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(left);
                hasALeftBuddy = true;
            }
        }
    }

    //right or left = 1 or -1
    //a function that creates a buddy on the side required
    void MakeNewBuddy(int rightOrLeft)
    {
        //calculating the new position for our new buddy
        //計算新的座標給需要生成的Sprite
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
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
        //newBuddy.transform.parent = parents.transform;

        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;

        }

    }

    void Recycle()
    {
        if (GameObject.FindGameObjectWithTag("Ground").transform.position.x <= recyclePoint.position.x)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ground"));
        }
    }

    #endregion
}
