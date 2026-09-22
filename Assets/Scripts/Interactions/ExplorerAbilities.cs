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
        if (e.interactable is ClimbInteractable climbInteractable) { 
            ClimbableWall climbableWall = climbInteractable.GetClimbableWall();

            if (climbInteractable.GetClimbAction() == ClimbAction.Climb) { 
                Climb(climbableWall);
            } 
            else if (climbInteractable.GetClimbAction() == ClimbAction.Drop) {
                 Drop(climbableWall);
            }
        }
    }

    private void Climb(ClimbableWall climbableWall) { 
        transform.position = climbableWall.GetTopDestination();
    }

    private void Drop(ClimbableWall climbableWall) {
        transform.position = climbableWall.GetBottomDestination();
    }
}
