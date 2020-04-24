using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UICanvas : MonoBehaviour
    {
        
        public UIDialogueWindow DialogueWindow;
        public Image Background;
        public Button CloseButton;

        private void Awake()
        {
            CloseButton.onClick.AddListener(OnCLoseButtonClicked);
        }

        public void ShowCloseButton()
        {
            Invoke("ActivateCloseButton", 3f);
        }

        private void ActivateCloseButton()
        {
            CloseButton.gameObject.SetActive(true);
        }

        private void OnCLoseButtonClicked()
        {
            Application.Quit();
        }
    }
}