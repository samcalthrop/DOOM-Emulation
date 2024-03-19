using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.8f;
    public float smoothing = 1.5f;

    private float xMousePos;
    //private float yMousePos;
    private float smoothedMousePosx;
    //private float smoothedMousePosy;

    private float currentLookingPosx;
    //private float currentLookingPosy;

    void Start()
    {
        // lock + hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        RotatePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        //yMousePos = Input.GetAxisRaw("Mouse Y");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        //yMousePos *= sensitivity * smoothing;
        smoothedMousePosx = Mathf.Lerp(smoothedMousePosx, xMousePos, 1f / smoothing);
        //smoothedMousePosy = Mathf.Lerp(smoothedMousePosy, yMousePos, 1f / smoothing);
    }

    void RotatePlayer()
    {
        currentLookingPosx += smoothedMousePosx;
        //currentLookingPosy += smoothedMousePosy;
        transform.localRotation = UnityEngine.Quaternion.AngleAxis(currentLookingPosx, transform.up);
        //transform.localRotation = Quaternion.AngleAxis(-currentLookingPosy, transform.right);


        // // // // transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
    }
}
