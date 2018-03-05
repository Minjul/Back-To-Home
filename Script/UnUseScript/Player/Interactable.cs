/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using UnityEngine;

public class Interactable : MonoBehaviour {

    #region Variables
    public float radius;
    public Transform interactionTransform; //Note 3. 角色面向位置
                                           //在2D的世界，目前還沒試過可不可以用Transform.LookAt()
                                           //如果不能夠使用LookAt()那就需要寫一個角色面對方向的判斷
                                           //原因是
                                           //假設有一個抽屜他的座標x小於玩家且其開口向左邊
                                           //那麼玩家必須站在interactionTransform的座標並且面向其物件並且互動觸發動畫
                                           //因此需要一個判斷，來設定腳色的面向位置
    bool hasInteracted = false;
    bool isFocus = false;       //用來偵測此物件是否被腳色鎖定，也可以利用此來判斷該物件是否距離夠近可以interact
    Transform player;
    #endregion

    #region Unity Methods
    public virtual void Interact()
    {
        //用來覆寫可互動物件的行為
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        //如果被鎖定了且還沒有與該物件互動過
        if (isFocus && !hasInteracted)
        {
            //檢查物件與角色的距離，如果距離小於指定的radius那就可以互動
            float distance = Vector3.Distance(player.position, interactionTransform.position); //playerBehavior的betweenDistance與這裡的radius不一致                                                                             //Undone 完成todo Change betweenDistance to Interactable.raidus 以優化此項目
            Debug.Log(distance);
            if (distance <= radius)
            {
                Debug.Log("distance <= radius");
                Interact();
                hasInteracted = true;
            }
        }
    }
    //Note 這個Method可以滿足Update中if的執行條件
    //鎖定滑鼠所點擊的可互動物件
    public void OnFocused(Transform playerTransform)
    {
        Debug.Log("Try to OnFocused()");
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        Debug.Log("OnFocused() Successed");
    }

    //取消鎖定目前鎖定的可互動物件
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);    
    }
    #endregion
}
