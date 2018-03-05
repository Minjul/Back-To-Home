/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    #region Property


    #endregion

    #region Variables

    public Dialogue dialogue;
    public Transform target;
    public Transform player;
    public float radius = 3f;

    Animator animator;

    bool startDialogue = false;
    bool canDetect = true;

    #endregion

    #region Unity Methods

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        //因為Update一直重複執行?
        TriggerDialogue();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, radius);
    }

    public void TriggerDialogue()
    {
    //對話偵測器註解
    //在最外面額外設一個bool值，其bool值為偵測器開關
    //當玩家進到偵測器範圍內時將偵測器的開關關閉，同時也將控制對話發送的bool設定為true
    //此時對話會開始發送，而偵測器則為false所以不會重複偵測重複執行
        float distance = Vector3.Distance(player.position, target.position);
        if (canDetect)
        {
            //Debug.Log(distance);
            //把FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 放在這裡也沒用
            //與用bool值判斷相同
            if (distance <= radius)
            {
                animator.SetBool("Open", true);
                startDialogue = true;
                canDetect = false; 
            }
            if (startDialogue)
            {
                Debug.Log("startDialogue");
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        if (distance >= radius)
        {
            startDialogue = false;
            canDetect = true;
        }
    }
    #endregion
}
