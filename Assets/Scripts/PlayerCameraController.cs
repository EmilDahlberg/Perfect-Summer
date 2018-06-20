using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour {
    public float xSensitivity;
    public float ySensitivity;
    public float maxYAngle = 80f;
    private bool changedSettings;

    private Vector2 currentRotation;

    private GameManagerController gameManager;
    private float rotateSpeed = 0.5f;
    Transform cameraPivot;
    Vector2 rotationSpeed = new Vector2(100, 80);   // Camera rotation speed for each axis
    Player player;



  
    void Awake() {
        player = ReInput.players.GetPlayer(0);
        cameraPivot = Camera.main.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerController>();
       
    }

    // Update is called once per frame
    void Update() {
 
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);

        if (gameManager.usingKeyboard) {
            MouseInputCamera();
        }
        

    }

    void MouseInputCamera() {

        if (gameManager.usingKeyboard) {

            currentRotation.x += player.GetAxis("LookRight") * xSensitivity;
            currentRotation.y -= player.GetAxis("LookUp") * ySensitivity;
            currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
            currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        }


    }

    void JoyStickCamera() {

      
    }

 
}

