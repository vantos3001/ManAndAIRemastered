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
            
            var dialogueNode = DialogueManager.Instance().StartDialogue();
            UpdateView(dialogueNode);
        }
        
        private void Update(){
            if (Input.GetKeyDown(KeyCode.Space) && !_uiManager.IsAnswerPanelOpened()){
                ChangePhrase();
            }
        }

        private void ChangePhrase(){
            var dialogueNode = DialogueManager.Instance().NextDialoguePhrase();
            UpdateView(dialogueNode);

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
            _uiManager.SetTextPanel(dialogueNode.GetDialogueText());
            
            var isHideTextPanel = dialogueNode.IsHideText();
            if (isHideTextPanel){
                _uiManager.HideTextPanel();
            }
            else{
                _uiManager.ShowTextPanel();
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