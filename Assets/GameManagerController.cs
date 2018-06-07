using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {
    [Header("Controllers")]
    public bool usingController;
    public bool usingKeyboard;

    [Header("Options")]
    public bool lockCursor;

	void Start () {
        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
