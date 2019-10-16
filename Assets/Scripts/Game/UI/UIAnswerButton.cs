using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIAnswerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private TextMeshProUGUI _text;
        
        private int _answerId;

        public Action<int> OnButtonClicked;

        private void Awake(){
            _button.onClick.AddListener(NotifyOnButtonClicked);
        }

        public void SetText(string text){
            _text.text = text;
        }

        public void SetActive(bool isActive){
            _button.gameObject.SetActive(isActive);
        }

        public void SetAnswerId(int id){
            _answerId = id;
        }

        private void NotifyOnButtonClicked(){
            OnButtonClicked?.Invoke(_answerId);
        }
    }
}