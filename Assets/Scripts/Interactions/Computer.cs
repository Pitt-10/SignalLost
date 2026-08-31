using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable {

    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] private GameInput gameInput;

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

        gameInput.DisableMovement();

        Debug.Log("Entrando a la computadora");
    }

    public void ExitComputer() { 
        if(!isUsing) 
            return;

        isUsing = false;

        gameInput.EnableMovement();

        Debug.Log("Saliendo de la computadora");
    }

    public void Update() {
        if (gameInput.GetExitComputerPressed()) { 
            ExitComputer();
        }
    }
}
