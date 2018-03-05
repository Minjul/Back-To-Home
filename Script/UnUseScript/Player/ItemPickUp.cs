/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using UnityEngine;

public class ItemPickUp : Interactable
{

    #region Variables

    PlayerControllerMouseVer playerControllerMouse;
    #endregion

    #region Unity Methods

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        #region Serious Bug 1. 換了場景後問題又跑出來了
        //Note 換了場景後問題又跑出來了
        //果然...
        //之後移動的行為必須要重寫
        //應該是因為到了目的地而停止移動
        //而非因為東西被撿起來了所以停止移動...
        //這樣寫就表示每一次在互動完如果想要角色停下來都必須要加一行
        //playerControllerMouse.IsMoving = false;
        //很智障...
        #endregion

        playerControllerMouse = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerMouseVer>();
        playerControllerMouse.IsMoving = false;
        Debug.Log("isMoving" + playerControllerMouse.IsMoving);

    }
    #endregion
}
