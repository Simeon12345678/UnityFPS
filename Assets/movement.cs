using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    [SerializeField]
    float jumpForce = 30;

    [SerializeField]
    float gravityMultiplier = 4;

    Vector2 inputVector;

    float yVelocity = 0f;

    bool isJumping = false;

    void Update()
    {
        Vector3 movement = transform.forward * inputVector.y + transform.right * inputVector.x;
        movement *= speed;

        if (GetComponent<CharacterController>().isGrounded)
        {
            yVelocity = -1;
            if (isJumping)
            {
                yVelocity = jumpForce;
            }
        }

        yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

        movement.y = yVelocity;

        GetComponent<CharacterController>().Move(movement * Time.deltaTime);
    }

    void OnMove(InputValue value) => inputVector = value.Get<Vector2>();
    void OnJump(InputValue value) => isJumping = true;
}