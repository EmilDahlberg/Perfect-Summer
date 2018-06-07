using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCameraController : MonoBehaviour {
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;

    private GameManagerController gameManager;
    private float rotateSpeed = 0.5f;
    Transform cameraPivot ;
    Vector2 rotationSpeed = new Vector2( 100, 50 );   // Camera rotation speed for each axis
    Player player;

    // Use this for initialization
    void Awake() {
        player = ReInput.players.GetPlayer(0);
        cameraPivot = Camera.main.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerController>();
    }

    // Update is called once per frame
    void Update() {
        if (gameManager.usingController) JoyStickCamera();
        if (gameManager.usingKeyboard) MouseInputCamera();
   

    }

    void MouseInputCamera() {
    
        currentRotation.x += player.GetAxis("LookRight") * sensitivity;
        currentRotation.y -= player.GetAxis("LookUp") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
       
    }

    void JoyStickCamera() {

        // Get the input vector from keyboard or analog stick
        var directionVector = new Vector3(player.GetAxis("LookUp"), 0, player.GetAxis("LookRight"));
        // Rotate around y - axis

        if (directionVector != Vector3.zero) {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            var directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }




        // Rotate the camera
        var camRotation = Vector2.zero;
        camRotation = new Vector2(player.GetAxis("LookRight"), player.GetAxis("LookUp"));
        camRotation.x *= rotationSpeed.x;
        camRotation.y *= rotationSpeed.y;
        camRotation *= Time.deltaTime;

        // Rotate the character around world-y using x-axis of joystick
        transform.Rotate(0, camRotation.x, 0, Space.World);
        // Rotate only the camera with y-axis input
        cameraPivot.Rotate(-camRotation.y, 0, 0);
    }

}

