using System;
using Game.UI;
using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        public void Initialize(){
            var dialogueNode = DialogueManager.Instance().StartDialogue();
            UpdateView(dialogueNode);
        }
        
        private void Update(){
            if (Input.GetKeyDown(KeyCode.Space)){
                ChangePhrase();
            }
        }

        private void ChangePhrase(){
            var dialogueNode = DialogueManager.Instance().NextDialoguePhrase();
            UpdateView(dialogueNode);

        }

        private void UpdateView(DialogueNode dialogueNode){
            var uiManager = UIManager.Instance();
            
            uiManager.SetTextPanel(dialogueNode.GetDialogueText());

            var newBackground = dialogueNode.GetNewBackground();
            if (!string.IsNullOrEmpty(newBackground)){
                uiManager.SetBackground(newBackground);
            }

            var isHideTextPanel = dialogueNode.IsHideText();
            if (isHideTextPanel){
                uiManager.HideTextPanel();
            }
            else{
                uiManager.ShowTextPanel();
            }
        }
    }
}