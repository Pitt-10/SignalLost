using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackerMinigame : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private TMP_Text textDisplay;
    [SerializeField] private TMP_InputField codeInput;

    private void Start() {
        textDisplay.text = text;

        codeInput.onValueChanged.AddListener((inputText) => {
            codeInput.text = inputText.ToUpper();
        });

        string code = GetCode();

        Debug.Log(code);
    }

    private string GetCode() {
        string code = "";

        foreach (char character in text) {
            if (char.IsUpper(character) || char.IsDigit(character)) { 
                code += character;
            }
        }
        return code;
    }

    private string GetPlayerCode() { 
        return codeInput.text;
    }

    public void ConfirmCode() { 
        string correctCode = GetCode();
        string playerCode = GetPlayerCode();

        if (playerCode == correctCode) {
            Debug.Log("Correcto");
        } else {
            Debug.Log("Incorrecto");
        }
    }
}
