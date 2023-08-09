using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float Speed = 10f;
    public float JumpForce = 300f;

    private bool _isGrounded;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        characterController.Move(movement * Speed * Time.deltaTime);
    }
}
