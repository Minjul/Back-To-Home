/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverBehaviour : MonoBehaviour {

    #region Variables
    public float shakeSeconds = 0.2f;

    Transform a;
    bool isShaking = false;
    bool canHovered = true;
    float waitTime;

    #endregion
	
	#region Unity Methods

	void Start ()
	{
        a = GetComponent<Transform>();
	}

    void Update()
    {
        Shake();
    }

    void OnMouseOver()
    {
        //滑過去的瞬間不應該是一個行為，這樣只要滑鼠一離開該物件，此行為就不會繼續，所以滑過去的瞬間應該是一個bool值的開關
        //執行順序是 
        //1.滑過物件bool值 = ture 
        //2.在別的function做事情 
        //3.做完事情後該function把剛剛的bool值 = false;
        //要只能執行一次
        //目前最大的問題是玩家將滑鼠放在物件上面時，會一直重複執行。
        
        if (canHovered)
        {
            StartCoroutine("WaitForShake");
            canHovered = false;
        }
        
        
    }
    void OnMouseExit()
    {
        canHovered = true;
        //canShake = true;
        //timed = false;
        //Debug.Log(canShake);
        //Debug.Log(shaked);
    }
    //忽然想到一個問題是不是應該要用Time.deltatime
    //Time.time 是遊戲時間不管有沒有呼叫他都會一直在背景做計算
    void Shake()
    {
        #region   摺疊
        //if (isShaking)
        //{
        //    Debug.Log("in shaking");
        //    float shakeValue = Random.Range(-30f, 31f);
        //    transform.rotation = Quaternion.Euler(0f, 0f, shakeValue);
        //    //成功讓它只動一次了接下來是動的方式
        //    //目前是在1秒內瘋狂抖動
        //}
        #endregion

        if (isShaking)
        {
            Debug.Log("is shaking");
            a.rotation = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.Lerp(transform.rotation, a.rotation, 0.01f * Time.deltaTime);
        }


    }

    IEnumerator WaitForShake()
    {
        Debug.Log("In Coroutine");

        if(isShaking == false)
        {
            isShaking = true;
        }
        
        yield return new WaitForSeconds(shakeSeconds);

        isShaking = false;
        Debug.Log(canHovered);
        a.rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, a.rotation, 0.01f * Time.time);
    }
    #endregion
}
