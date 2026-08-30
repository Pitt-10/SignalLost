using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable {

    [SerializeField] private PlayerInteraction playerInteraction;

    private bool isUsing;

    private void Awake() {
        playerInteraction.OnInteract += PlayerInteraction_OnInteract;
    }

    private void PlayerInteraction_OnInteract(object sender, InteractEventArgs e) {
        if (e.interactable == this) { 
            Interact();
        }
    }

    public void Interact() {
        if (isUsing)
            return;

        isUsing = true;

        Debug.Log("Entrando a la computadora");
    }
}
