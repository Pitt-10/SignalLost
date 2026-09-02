using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject hackerMinigame;

    public void Show() { 
        gameObject.SetActive(true);
    }
    public void Hide() {
        gameObject.SetActive(false);
    }

    public void AccessComputer() {
        content.SetActive(false);
        hackerMinigame.SetActive(true);
        
    }
}
