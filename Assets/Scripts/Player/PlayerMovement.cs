using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private GameInput gameInput;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        gameInput = GetComponent<GameInput>();
    }

    private void Update() {
        if (gameInput.GetJumpPressed() && IsGrounded()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() {
        Vector2 inputVector = gameInput.GetMovementVector();

        Vector3 moveDirection =
        transform.right * inputVector.x +
        transform.forward * inputVector.y;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
