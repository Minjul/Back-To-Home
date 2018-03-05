/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour {

    #region Variables
    RectTransform mRectTransform;

    public GameObject inventoryPanel;
    public bool inventoryOut;
    public int screenOffset;
    public float moveSpeed;
    public float panelOffset;

    private float targetY;
    private float originY;
    //private int theScreenWidth;
    //private int theScreenHeight;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        mRectTransform = inventoryPanel.GetComponent<RectTransform>();
    }

    void Start ()
	{
        //theScreenWidth = Screen.width;
        //theScreenHeight = Screen.height;
        inventoryOut = false;
        originY = mRectTransform.localPosition.y;
        targetY = mRectTransform.localPosition.y + panelOffset;
    }
	

	void Update () 
	{
        mouseNearEdge();
        
    }

    private void mouseNearEdge()
    {
        if (Input.mousePosition.y < 0 + screenOffset && !inventoryOut)
        {
            //Debug.Log("Try to Open");
            mRectTransform.localPosition = new Vector2(mRectTransform.localPosition.x, mRectTransform.localPosition.y + moveSpeed);
            inventoryPanel.transform.localPosition = mRectTransform.localPosition;
            Debug.Log("Y = " + mRectTransform.localPosition.y);

            //這個當然進不去...mRectTransform.localPosition.y 一直在自增
            //是一個浮動值，而比較值是自己+162，當然永遠都追不上...
            if (mRectTransform.localPosition.y > targetY)
            {
                inventoryOut = true;
            }

        }
        if (Input.mousePosition.y > 0 + screenOffset && inventoryOut)
        {
            //Debug.Log("Try to Close");
            mRectTransform.localPosition = new Vector2(mRectTransform.localPosition.x, mRectTransform.localPosition.y - moveSpeed);
            inventoryPanel.transform.localPosition = mRectTransform.localPosition;
            Debug.Log("Y = " + mRectTransform.localPosition.y);

            if (mRectTransform.localPosition.y < originY)
            {
                inventoryOut = false;
            }

        }
    }
	
	#endregion
}
