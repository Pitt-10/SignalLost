using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private GameInput gameInput;

    private void Awake() {
        gameInput = GetComponent<GameInput>();
    }
}
