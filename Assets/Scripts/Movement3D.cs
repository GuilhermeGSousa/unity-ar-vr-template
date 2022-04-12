using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3D : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private PlayerInput input;
    [SerializeField] private CharacterController characterController;
    private Vector2 moveInput = Vector2.zero;

    [SerializeField] private LayerMask isGround;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private float gravityScale = 0.1f;
    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void Update() 
    {
        CheckGround();
        UpdateVelocity();

        var moveVector = (transform.forward * moveInput.y) * Time.deltaTime * speed;
        characterController.Move(velocity * Time.deltaTime + moveVector);

        var rotationInput = moveInput.x;
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }

    private void CheckGround()
    {
        isGrounded = Physics.OverlapSphere(transform.position, groundCheckRadius, isGround).Length > 0;
    }

    private void UpdateVelocity()
    {
        velocity += gravityScale * Physics.gravity * Time.deltaTime;

        if(isGrounded && velocity.y < 0) velocity.y = 0f;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }

}
