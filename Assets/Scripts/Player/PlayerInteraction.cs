using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private float interactionDistance = 2f;

    private void Update() {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, interactionDistance)) {
            Debug.Log(raycastHit.transform.name);
        }
    }
}
