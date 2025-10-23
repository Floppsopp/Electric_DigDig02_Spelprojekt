using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    
    // Player speed
    public float Speed = 5f;

    // smooth turning for the character
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Jumpheight for the player
    float jumpHeight = 1f;

    // gravity and velocity to make the player be grounded when not jumping 
    float gravity = 9.82f;
    public float verticalVelocity;

    // Checks if the player is touching the ground.
    public bool Grounded;

    void Update()
    {
        Movement();
        VerticalForce();
    }

    //Movement script
    void Movement()
    {
        //Assigns axis for the player movement (not jump).
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // player move speed is normalized and doesn't accelerate.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //for the Vertical velocity to work
        Vector3 move = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            //Movement and smooth turning
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Makes the player move smoother when turning.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //changes player direction. ex, player turns left is going to face left.
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * Speed * Time.deltaTime);
        }
        // verticalVelocity getting assigned to y cordinate
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }

    //Code for jump function
    float VerticalForce()
    {
        if (controller.isGrounded)
        {
            // If grounded the vertical velocity is kept at -1f so it stays on the ground 
            verticalVelocity = -1f;
            Grounded = true;
            // When the button space ("Jump") is pressed the player jumps.
            if (Input.GetButtonDown("Jump"))
            {
                // Equation for jumping
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