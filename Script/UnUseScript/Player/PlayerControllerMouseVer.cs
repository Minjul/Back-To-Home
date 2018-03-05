/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehavior))]
public class PlayerControllerMouseVer : MonoBehaviour {

    #region Variables

    PlayerBehavior playerBehavior;
    Interactable interactable;

    [SerializeField]
    private bool isMoving;

    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
        set
        {
            isMoving = value;
        }
    }

    public float moveSpeed;//Floating point variable to store the player's movement speed.
    public Interactable focus; //target to focus

    private GameObject arrows;
    private Vector2 targetPosition;
    private string targetName;
    private float timer = 1;
    private bool haveTarget;
    #endregion

    #region Unity Methods
    void Start()
    { 
        playerBehavior = GetComponent<PlayerBehavior>();
        interactable = GetComponent<Interactable>();
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTarget();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            playerBehavior.MovePlayer(targetPosition, moveSpeed);
            //Note 
            //...好吧我錯了就算start沒設定預設值依然是(0,0)
            //當interactableTarget == null後就會把之前的所在位置放在targetPosition裡面傳過去
        }
    }

    private void SetTarget()
    {
        #region 追蹤目標邏輯更改方向
        //UnDone 追蹤目標的邏輯需要改
        //更改方向
        //1. 當目前targetPosition 的座標，與新的座標相同時，不要再傳遞新的座標過去
        //2. 不要用isMoving作為是否移動的依據，應該以是否有"目標"進行追蹤為依據
        //3. 考慮是否不要傳遞targetPosition，目前的問題就是因為無論如何只要在執行playerBehavior.MovePlayer(targetPosition, moveSpeed);
        //   就會把targetPosition傳過去，導致發生這次嚴重Bug的結果
        //4. 從Debug可以得知系統一直重複地在設置目標的座標
        //   應該在每一次點擊一次滑鼠的時候才設置一次
        //5. 因為這裡的錯誤所以導致Brackeys的SetFocus()在判斷是否已經取得值以避免重複取得的邏輯
        //   變得沒有意義
        #endregion
        if (haveTarget)
        {
            haveTarget = false;
        }

        if (focus != null)
        {
            RemoveFocus();
        }
        //Note ray.origin 應該要即時改成角色座標?
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        float point = 0f;

        if (hit.collider == null)
        {
            Debug.Log("this object don't have collider");
            return;
        }

        if (hit.collider.tag == "Ground" && !haveTarget)
        {
            targetPosition = ray.GetPoint(point);
            haveTarget = true;
        }
        else if (hit.collider.tag == "Interactable" && !haveTarget)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            //例如: 從 Bag 物件中取得 Interactable 組件
            if (interactable != null)
            {
                //isMoving = true; 這裡先被設定完true才設定跟隨，所以座標等於預設值的targetPosition已經被傳過去了(0,0)
                targetName = hit.transform.name;
                Debug.Log(targetName + " this object is interactable");//Debug 出物件名稱
                SetFocus(interactable); //將可互動物件的資訊傳給SetFocus(Interactable newFocus)
                haveTarget = true;
            }
        }
        else
        {
            //點其他的物件會是空值不會執行這一行
            //是因為其他物件沒有collider，如果點擊的是"公園的邊境"的話就會跳到這一行
            //因為該物件有collider
            Debug.Log("this object don't have tag for RaycastHit");
            return;
        }
        isMoving = true;
    }

    #region From Brackeys Making an RPG in Unity (E02)
    //Note is really necessary use Brackeys code to track target?
    void SetFocus(Interactable newFocus)
    {
        #region SetFocus(Interactable newFocus) 註釋
        //檢查newFocus的物件是否與角色正在鎖定的物件(focus)是同一個
        //如果是同一個物件，將角色的座標傳給Interactable，來判斷物件與角色的間距
        //如果不是同一個，那就判斷focus中有沒有值
        //如果不是空值，將鎖定取消後，並將鎖定的物件改為newFocus，並且跟隨它
        //如果是空值的話，就將角色鎖定目標設定為newFocus，並且跟隨它
        #endregion
        if (newFocus != focus)
        {

            if(focus!= null) //如果focus!= null 將所有參數歸零
            {
                focus.OnDeFocused(); 
            }
            focus = newFocus;
            playerBehavior.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform); //將角色的座標傳給Interactable，來判斷物件與角色的間距
    }

    void RemoveFocus()
    {
        #region RemoveFocus()註釋
        //檢查focus中是否有值
        //如果有值，將Interactable中的相關參數歸零，並將focus歸零，角色也停止跟隨目標
        //如果沒有值，直接將focus歸零，並且角色停止跟隨目標
        #endregion
        if (focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
        playerBehavior.StopFollowingTarget();
    }
    #endregion

    #region 待搬運的Anim()
    //todo 4. Make other class to control the animation
    
    #endregion

    //todo 2. code CreateArrow() method to other class
    //Remanber your object is not in the scene so you can't just refrence to your script 
    //You need to use 'Resource' to load your object
    //The object you 'instantiate' which type is 'Object' not 'GameObject' so you need to change type to 'GameObject'
    //Add 'as GameObject' in the end of the line.
    #endregion
}
