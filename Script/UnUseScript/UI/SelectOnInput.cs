/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    #region Variables

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

	#endregion
	
	#region Unity Methods
	
	void Update () 
	{
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
	}
	
    private void OnDisable()
    {
        buttonSelected = false;
    }

	#endregion
}
