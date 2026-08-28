using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float lookSensitivity = 0.2f;

    private float cameraPitch;

    private GameInput gameInput;

    private void Awake() {
        gameInput = GetComponent<GameInput>();
    }

    private void Update() {
        Vector2 lookInput = gameInput.GetLookVector();

        float yaw = lookInput.x * lookSensitivity;
        float pitch = lookInput.y * lookSensitivity;

        transform.Rotate(Vector3.up, yaw);

        cameraPitch -= pitch;

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

    }
}
