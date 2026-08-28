using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable {
    public void Interact() {
        Debug.Log("Interactuando con la computadora");
    }
}
