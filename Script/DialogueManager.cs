/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region Property


    #endregion

    #region Variables
    //public Text nameText;
    public Text dialogueText;

    Queue<string> sentences;

    bool firstTimeDialogue = true;
    bool nextDialogue = false;
    #endregion
	
	#region Unity Methods

	void Start ()
	{
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (nextDialogue)
        {
            NextSentenceTrigger();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        nextDialogue = true;
    }

    public void NextSentenceTrigger()
    {
        if (firstTimeDialogue)
        {
            DisplayNextSentence();
        }
        if (!firstTimeDialogue)
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                DisplayNextSentence();
            }
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Debug.Log(sentences.Count);
            EndDialouge();
            return;
        }
        Debug.Log(firstTimeDialogue);
        //將queue的長度 = 移除一個queue之後的長度
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        firstTimeDialogue = false;
        Debug.Log(firstTimeDialogue);

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialouge()
    {
        Debug.Log("Dialouge End.");
        firstTimeDialogue = true;
        nextDialogue = false;
    }

    #endregion
}
