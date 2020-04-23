using System;
using Game.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInputField : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _okButton;

    private void Awake()
    {
        _inputField.onValueChanged.AddListener(OnValueChanged);
        _okButton.onClick.AddListener(OnOkButtonClicked);
    }

    public void UpdateView(DialogueNode node)
    {
        IsHaveInput = node.IsInput();

        if (IsHaveInput)
        {
            gameObject.SetActive(true);
            _okButton.interactable = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
    public bool IsHaveInput { get; private set; }

    private void OnValueChanged(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            _okButton.interactable = false;
        }
        else
        {  
            _okButton.interactable = true;
        }
    }

    private void OnOkButtonClicked()
    {
        IsHaveInput = false;
        gameObject.SetActive(false);
        EventManager.HandleOnPlayerNameInputEnded(_inputField.text);
        _inputField.text = "";
    }
}
