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

    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private float crouchingHeight = 1f;

    private float standingHeight;
    private Vector3 standingCenter;
    private Vector3 crouchingCenter;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float crouchCameraOffset = 0.5f;

    private Vector3 standingCameraPosition;

    private GameInput gameInput;
    private Rigidbody rb;

    private bool jumpRequested;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        gameInput = GetComponent<GameInput>();

        standingCenter = capsuleCollider.center;
        standingHeight = capsuleCollider.height;

        crouchingCenter = standingCenter;
        crouchingCenter.y = standingCenter.y - (standingHeight - crouchingHeight)/2f;

        standingCameraPosition = playerCamera.localPosition;
    }

    private void Update() {
        if (gameInput.GetJumpPressed() && IsGrounded()) {
            jumpRequested = true;
        }

        HandleCrouch();
    }

    private void FixedUpdate() {
        Vector2 inputVector = gameInput.GetMovementVector();

        Vector3 moveDirection =
        transform.right * inputVector.x +
        transform.forward * inputVector.y;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        
        if (jumpRequested) { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    private bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void HandleCrouch() {
        if (gameInput.GetCrouchPressed()) {
            capsuleCollider.height = crouchingHeight;
            capsuleCollider.center = crouchingCenter;

            playerCamera.localPosition = standingCameraPosition + Vector3.down * crouchCameraOffset;
        } else {
            capsuleCollider.height = standingHeight;
            capsuleCollider.center = standingCenter;

            playerCamera.localPosition = standingCameraPosition;
        }
    }
}
