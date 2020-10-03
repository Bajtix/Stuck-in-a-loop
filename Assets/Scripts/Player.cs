using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Transform cameraTransform;
    public CharacterController character;
    private float jumpForce;
    public float playerJump = 10;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movement = input * Time.deltaTime * speed + jumpForce * Vector3.up * Time.deltaTime;

        if (!character.isGrounded)
            jumpForce += Physics.gravity.y * Time.deltaTime;
        else
        {
            if (Input.GetButton("Jump"))
                jumpForce = playerJump;
            else 
                jumpForce = 0;
        }



        jumpForce = Mathf.Clamp(jumpForce,Physics.gravity.y * 2, 99999);

        character.Move(transform.TransformDirection(movement));

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));

        transform.rotation *= Quaternion.Euler(0, mouseInput.x, 0);
        cameraTransform.localRotation *= Quaternion.Euler(mouseInput.y, 0,0);
    }
}
