using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private GameInput gameInput;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        gameInput = GetComponent<GameInput>();
    }

    private void FixedUpdate() {
        Vector2 inputVector = gameInput.GetMovementVector();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
