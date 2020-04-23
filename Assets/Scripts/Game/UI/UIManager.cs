using System;
using Game.Dialogue;
using UnityEngine;

namespace Game.UI
{
    public class UIManager
    {
        private static UIManager _manager;
        private UICanvas _canvas;

        public event Action<int> OnAnswerButtonClicked; 

        private UIManager(){
            _canvas = GameObject.FindWithTag("Canvas").GetComponent<UICanvas>();

            _canvas.AnswerPanel.AnswerButtonClicked += NotifyAnswerButtonClicked;
        }

        public TypeWriterPanel TextPanel => _canvas.TextPanel;

        public void SetBackground(string backgroundName){
            var background = DataManager.GetSpriteBackground(backgroundName);
            _canvas.Background.sprite = background;
        }
        
        public void ShowTextPanel(){
            var textPanelGO = _canvas.TextPanel.gameObject;
            if (!textPanelGO.activeSelf){
                _canvas.TextPanel.gameObject.SetActive(true);
            }
        }

        public void HideTextPanel(){
            _canvas.TextPanel.gameObject.SetActive(false);
        }

        public bool IsHideTextPanel()
        {
            return !_canvas.TextPanel.isActiveAndEnabled;
        }

        public void ShowAnswerPanel(DialogueNode dialogueNode){
            _canvas.AnswerPanel.gameObject.SetActive(true);
            _canvas.AnswerPanel.UpdateButtons(dialogueNode);
        }

        public void HideAnswerPanel(){
            _canvas.AnswerPanel.gameObject.SetActive(false);
        }

        public bool IsAnswerPanelOpened(){
            return _canvas.AnswerPanel.gameObject.activeSelf;
        }

        private void NotifyAnswerButtonClicked(int answerId){
            OnAnswerButtonClicked?.Invoke(answerId);
        }

        public static UIManager Instance(){
            if (_manager == null){
                _manager = new UIManager();
            }

            return _manager;
        }
    }
}