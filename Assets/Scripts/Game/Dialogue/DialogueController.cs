using System;
using Game.UI;
using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueController : MonoBehaviour
    {

        private UIManager _uiManager;
        
        public void Initialize(){
            _uiManager = UIManager.Instance();
            _uiManager.OnAnswerButtonClicked += OnAnswerButtonClicked;

            EventManager.DialoguePhraseChanged += UpdateView;
            
            DialogueManager.Instance().StartDialogue();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleMouseLeftClick();
            }
        }

        private void HandleMouseLeftClick()
        {
            if(!_uiManager.IsAnswerPanelOpened())
                if (_uiManager.TextPanel.IsWaitForClick || _uiManager.IsHideTextPanel())
                {
                    ChangePhrase();
                }
        }
        
        private void ChangePhrase(){
            DialogueManager.Instance().NextDialoguePhrase();
        }

        private void ChangePhraseByAnswer(int answerId){
            var dialogueNode = DialogueManager.Instance().NextDialoguePhraseByAnswerId(answerId);
            UpdateView(dialogueNode);
        }

        private void UpdateView(DialogueNode dialogueNode){
            
            UpdateTextPanel(dialogueNode);
            UpdateAnswerPanel(dialogueNode);

            var newBackground = dialogueNode.GetNewBackground();
            if (!string.IsNullOrEmpty(newBackground)){
                _uiManager.SetBackground(newBackground);
            }
        }

        private void UpdateTextPanel(DialogueNode dialogueNode){           
            var isHideTextPanel = dialogueNode.IsHideText();
            if (isHideTextPanel){
                _uiManager.HideTextPanel();
            }
            else{
                _uiManager.ShowTextPanel();
                
                var textPanel = _uiManager.TextPanel;

                if (!textPanel.IsEffectPlayed){
                    textPanel.SetText(dialogueNode.GetDialogueText());
                }
            }

        }

        private void UpdateAnswerPanel(DialogueNode dialogueNode){
            if (dialogueNode.IsHasAnswers()){
                _uiManager.ShowAnswerPanel(dialogueNode);
            }
            else{
                _uiManager.HideAnswerPanel();
            }
        }

        private void OnAnswerButtonClicked(int answerId){
            ChangePhraseByAnswer(answerId);
        }
    }
}