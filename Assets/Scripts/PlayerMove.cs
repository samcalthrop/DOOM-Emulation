using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDamping = 1f;

    private CharacterController cc;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -9.8f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();

        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        // if W, A, S, or D are being held
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        } else
        {
            // otherwise linearly interpolate the last speed value towards 0
            inputVector = Vector3.Lerp(inputVector / 1.01f, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        cc.Move(movementVector * Time.deltaTime);
    }
}
