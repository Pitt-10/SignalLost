using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerAbilities : MonoBehaviour
{
    [SerializeField] private float climbCheckDistance = 1.5f;
    [SerializeField] private LayerMask climbableLayer;
    private bool CanClimb(){
        return Physics.Raycast(transform.position, transform.forward, climbCheckDistance, climbableLayer);
    }

    private void Update() {
        if (CanClimb()) {
            Debug.Log("Esta pared se puede trepar");
        }
    }
}
