using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Cinemachine;

public class GameManagerController : MonoBehaviour {

    private CinemachineVirtualCamera virtCam;
    private CinemachinePOV pov;

    [Header("Controllers")]
    public bool usingController;
    public bool usingKeyboard;

    [Header("Options")]
    public bool lockCursor;

    [Header("Game settings")]
    [Header("Mouse settings")]

    public float mouseHorizontalMaxSpeed;
    public float mouseVerticalMaxSpeed;
    public float mouseAcceleration;
    public float mouseDeacceleration;

    [Header("Controller settings")]
    public float controllerVerticalMaxSpeed;
    public float controllerHorizontalMaxSpeed;
    public float controllerAcceleration;
    public float controllerDeacceleration;



    void Awake () {

        if(GameObject.FindGameObjectWithTag("VirtualCamera") != null) {
            virtCam = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
            pov = virtCam.GetCinemachineComponent<CinemachinePOV>();
            
        }

        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }


        if (usingKeyboard) {
            UsingKeyBoard();
        }

        if (usingController) {
            UsingController();
        }
	}
	

    void UsingKeyBoard() {
        if (virtCam.enabled) {
            virtCam.enabled = false;
        }
    }

    void UsingController() {

        if (!virtCam.enabled) {
            virtCam.enabled = true;
        }

        if (pov != null) {
            //Horizontal Axis
            pov.m_HorizontalAxis.m_MaxSpeed = controllerHorizontalMaxSpeed;
            pov.m_HorizontalAxis.m_AccelTime = controllerAcceleration;
            pov.m_HorizontalAxis.m_DecelTime = controllerDeacceleration;

            //Vertical Axis
            pov.m_VerticalAxis.m_MaxSpeed = controllerVerticalMaxSpeed;
            pov.m_VerticalAxis.m_AccelTime = controllerAcceleration;
            pov.m_VerticalAxis.m_DecelTime = controllerDeacceleration;
        }
        else {
            print("The virtual camera isn't accessed!");
        }
     }
}
