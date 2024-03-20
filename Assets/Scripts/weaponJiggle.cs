using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class weaponJiggle : MonoBehaviour
{
    [SerializeField]
    float smoothness = 8;

    [SerializeField]
    float sensitivity = 4;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothness * Time.deltaTime);
    }

    /*

    void OnLook(InputValue value)
    {
        Vector2 lookVector = value.Get<Vector2>();
        Quaternion rotationX = Quaternion.AngleAxis((-lookVector.y * sensitivity), Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis((lookVector.x * sensitivity), Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothness * Time.deltaTime);
    }

    */
}
