/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    #region Variables
    private bool focusToTarget; //用來判斷是鎖定物件移動還是普通移動
    public bool FocusToTarget
    {
        get
        {
            return focusToTarget;
        }
        set
        {
            focusToTarget = value;
        }
    }
    PlayerControllerMouseVer playerControllerMouse;
    Interactable interactableTarget;         //target to follow
    private float distanceOffset = 0.09f; //distance to offset the target 
                                          //Because the distance between player and the target can't completely equal to zero

    //以下註釋的變數先留著
    //private float betweenDistance = 0.9f; //This variable should equal to Interactable.radius
    //Transform interactableTarget;         //target to follow
    #endregion

    #region Unity Methods
    private void Start()
    {
        playerControllerMouse = GetComponent<PlayerControllerMouseVer>();
    }

    #region 筆記2.
    //Note 2. 跟隨系統目前無意義
    //interactableTarget這個判斷式目前沒有意義，因為目前用的是Vector2.MoveTowards()//其實可以進到MoveTowards() Method裡面看一下官方的MoveTowards()是怎寫的
    //Vector2.MoveTowards()只是走到該地點，單純的使用該Method在到了目的地之後，並不會有第二次的跟隨
    //Brackeys 使用的是Unity的 NavAgent系統，所以程式碼會簡短許多
    #endregion

    public void MovePlayer(Vector2 targetPosition, float moveSpeed)
    {
        #region Serious Bug 1. 找到問題了
        //Note 找到問題了
        //當interactableTarget == null後的下一幀就會把之前的所在位置放在targetPosition裡面傳過來
        //不能直接寫當 interactableTarget == null的時候 
        //把targetPosition設定成interactableTarget最後的位置
        //這樣會影響到普通移動時的移動邏輯

        //是否新增一個bool，判斷是移動、還是鎖定物件的座標?
        //用原有的interactableTarget做判斷比較省資源...

        //而外多創一個bool感覺很智障...
        //再來就是而外多創的bool
        //在hit.collider.tag == "Interactable"時為true
        //目前在playerControllerMouse.SetTarget()的最上面
        //將focusToTarget設為false，感覺很智障...
        #endregion

        if (interactableTarget != null)
        {
            targetPosition = interactableTarget.transform.position;

            //必須以物件以及玩家的座標作為標準
            //todo 3. Change betweenDistance to Interactable.raidus
            if (targetPosition.x > transform.position.x)
            {
                targetPosition = new Vector2(targetPosition.x - interactableTarget.radius + 0.7f, targetPosition.y);
                //Undone 請把interactableTarget.radius + 0.3f 修掉
                //       請把interactableTarget.radius - 0.3f 修掉
                //       不同物件會有不同的距離其物件的中心點都不同
            }
            if (targetPosition.x < transform.position.x)
            {
                targetPosition = new Vector2(targetPosition.x + interactableTarget.radius - 0.7f, targetPosition.y);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        float distance = (targetPosition.x - transform.position.x);

        Flip(distance);

        if (distance < 0)
        {
            distance *= -1;
        }
        if (distance <= distanceOffset)
        {
            playerControllerMouse.IsMoving = false;
            Debug.Log("isMoving " + playerControllerMouse.IsMoving);
        }
    }

    private void Flip(float targetDistance)
    {
        if (targetDistance > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }

        if (targetDistance < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }

    }
    #region From Brackeys Making an RPG in Unity (E02)

    #region 筆記1.
    //Note 1. 增加角色到達指定座標的準確度
    //用FollowTarget()角色移動的精準度非常高，角色的座標位置可以與物件位置完全等於0
    //滑鼠的邏輯可以改成生成(instantiate)移動的標點，並用FollowTarget()去跟隨
    //但是這樣寫可能會導致在角色移動到指定位置之前，標點都不能刪掉
    #endregion

    public void FollowTarget(Interactable newTarget)
    {
        //interactableTarget = newTarget.interactionTransform;//interactionTransform = 物件的可互動位置
        interactableTarget = newTarget;
    }
    public void StopFollowingTarget()
    {
        interactableTarget = null;
    }
    #endregion

    #endregion
}
