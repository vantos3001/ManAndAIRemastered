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
            if (Input.GetKeyDown(KeyCode.Space)){
                if (!_uiManager.IsAnswerPanelOpened()){
                    ChangePhrase();
                }
                else{
                    SkipPhrase();
                }
            }
        }

        private void ChangePhrase(){
            var dialogueNode = DialogueManager.Instance().NextDialoguePhrase();
            UpdateView(dialogueNode);

        }

        private void SkipPhrase(){
            var textPanel = _uiManager.TextPanel;

            if (textPanel.IsEffectPlayed){
                textPanel.SkipEffect();
            }
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

                if (textPanel.IsEffectPlayed){
                    textPanel.SkipEffect();
                }
                else{
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