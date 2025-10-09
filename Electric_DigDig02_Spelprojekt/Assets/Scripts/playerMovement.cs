using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController controller;
    public Transform camera1;

    float moveInput;
    float turnInput;
    public float walkSpeed = 5f;
    public float turnSpeed = 2f;
    float jumpHeight = 1f;

    float gravity = 9.82f;
    public float verticalVelocity;

    public bool Grounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputManagement();
        Movement();
        Turn();
        VerticalForce();
    }

    void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move.y = verticalVelocity;
        move *= walkSpeed;
        controller.Move(move * Time.deltaTime);
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > 0 || Mathf.Abs(moveInput) > 0)
        {
            Vector3 currentLookDirection = camera1.forward;
            currentLookDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }

    float VerticalForce()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
            Grounded = true;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            Grounded = false;
        }
        return verticalVelocity;
    }
}