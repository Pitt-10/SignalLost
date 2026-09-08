using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject hackerMinigame;
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject failedPanel;
    [SerializeField] private HackerMinigame hackerMinigameScript;
    [SerializeField] private Computer computer;

    private void OnEnable() {
        hackerMinigameScript.OnSuccess += HackerSuccess;
        hackerMinigameScript.OnFailed += HackerFailed;
    }

    private void OnDisable() {
        hackerMinigameScript.OnSuccess -= HackerSuccess;
        hackerMinigameScript.OnFailed -= HackerFailed;
    }

    public void Show() { 
        gameObject.SetActive(true);
    }
    public void Hide() {
        gameObject.SetActive(false);
    }

    public void AccessComputer() {
        content.SetActive(false);
        hackerMinigame.SetActive(true);
        successPanel.SetActive(false);
        failedPanel.SetActive(false);
    }

    public void ShowSuccessPanel() {
        hackerMinigame.SetActive(false);
        successPanel.SetActive(true);
    }

    public void ShowFailedPanel() {
        hackerMinigame.SetActive(false);
        failedPanel.SetActive(true);
    }

    public void HackerSuccess() { 
        ShowSuccessPanel();
    }

    private void HackerFailed() { 
        ShowFailedPanel();
    }

     public void ReturnToContent() {
        failedPanel.SetActive(false);
        content.SetActive(true);

        hackerMinigameScript.ResetMinigame();
    }

    public void ExitComputer() {
        computer.ExitComputer();
    }

}
