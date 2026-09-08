using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackerMinigame : MonoBehaviour {
    [SerializeField] private string[] texts;
    private string currentText;
    [SerializeField] private TMP_Text textDisplay;
    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private ComputerUI computerUI;
    [SerializeField] private TMP_Text attemptsText;
    [SerializeField] private TMP_Text errorText;

    private int attempts;
    private const int maxAttemtps = 3;

    public event System.Action OnSuccess;
    public event System.Action OnFailed;

    private void Start() {
        currentText = texts[Random.Range(0, texts.Length)];

        textDisplay.text = currentText;

        codeInput.onValueChanged.AddListener((inputText) => {
            codeInput.text = inputText.ToUpper();
        });

        string code = GetCode();

        Debug.Log(code);

        UpdateAttemptsText();

        codeInput.onValueChanged.AddListener(OnCodeInputChanged);
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
            errorText.gameObject.SetActive(false);
            OnSuccess?.Invoke();
        } else {

            attempts++;

            UpdateAttemptsText();

            if (attempts >= maxAttemtps) {

                errorText.gameObject.SetActive(false);

                OnFailed?.Invoke();
            } else {
                codeInput.text = "";
                errorText.gameObject.SetActive(true);
            }
        }
    }

    public void ResetMinigame() {
        attempts = 0;
        codeInput.text = "";

        errorText.gameObject.SetActive(false);

        UpdateAttemptsText();
    }

    private void UpdateAttemptsText() {
        attemptsText.text = "Intentos: " + attempts + "/" + maxAttemtps;
    }

    private void OnCodeInputChanged(string value) {
        errorText.gameObject.SetActive(false);
    }
}
