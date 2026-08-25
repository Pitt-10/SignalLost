using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInputActions inputActions;

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

    public Vector2 GerMovementVector(){
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
}
