using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInputActions inputActions;
    private Vector2 moveInput;

    private Rigidbody rb;

    private void Awake() {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable() {
        inputActions.Player.Enable();
    }
    private void OnDisable() {
        inputActions.Player.Disable();
    }

    private void Update() {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
    }
}
