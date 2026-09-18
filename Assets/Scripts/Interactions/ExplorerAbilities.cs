using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerAbilities : MonoBehaviour
{
    private PlayerInteraction playerInteraction;

    private void Awake() {
        playerInteraction = GetComponent<PlayerInteraction>();
        playerInteraction.OnInteract += PlayerInteraction_OnInteract;
    }

    private void PlayerInteraction_OnInteract(object sender, InteractEventArgs e) {
        if (e.interactable is ClimbableWall climbableWall) { 
            Climb(climbableWall);
        }
    }

    private void Climb(ClimbableWall climbableWall) {
        Debug.Log("El explorador intento trepar");
    }
}
