using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions inputActions;
 
    private void Awake() {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable() {
        inputActions.Player.Enable();
    }
    private void OnDisable() {
        inputActions.Player.Disable();
    }

    public Vector2 GetMovementVector(){
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    public Vector2 GetLookVector() {
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
}
