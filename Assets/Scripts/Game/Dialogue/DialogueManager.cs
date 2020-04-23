using Game.UI;
using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueManager
    {
        private static DialogueManager _manager;
        private DialogueSystem _dialogueSystem;
        
        
        private DialogueManager(){
            _dialogueSystem = new DialogueSystem();
            
            EventManager.OnAnswerButtonClicked += OnAnswerButtonClicked;
            EventManager.OnPlayerNameInputEnded += OnPlayerNameInputEnded;
        }
        
        public void StartDialogue(){
            _dialogueSystem.StartDialogue();

            UIManager.Instance().UpdateDialogueWindow(_dialogueSystem.CurrentDialogueNode);
            
            NotifyDialoguePhraseChanged();
        }
        
        private DialogueNode NextDialoguePhraseByAnswerId(int answerId){
            _dialogueSystem.NextByAnswerId(answerId);
            
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            return currentDialogueNode;
        }

        public void NextDialoguePhrase(){
            _dialogueSystem.Next();

            if (_dialogueSystem.IsEnded)
            {
                EndDialogue();
            }
            else
            {
                NotifyDialoguePhraseChanged();
            }
        }
        
        private void EndDialogue()
        {
            Debug.Log("End dialogue");
        }
        
        private void ChangePhraseByAnswer(int answerId){
            var dialogueNode = Instance().NextDialoguePhraseByAnswerId(answerId);
            UIManager.Instance().UpdateDialogueWindow(dialogueNode);
        }
        private void OnAnswerButtonClicked(int answerId){
            ChangePhraseByAnswer(answerId);
        }

        private void OnPlayerNameInputEnded(string playerName)
        {
            DataManager.PlayerName = playerName;
            NextDialoguePhrase();
        }

        private void NotifyDialoguePhraseChanged(){
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            EventManager.HandleDialoguePhraseChanged(currentDialogueNode);
        }
        
        public void Load(){
            _dialogueSystem.Load();
        }
        
        public static DialogueManager Instance(){
            if (_manager == null){
                _manager = new DialogueManager();
            }

            return _manager;
        }
    }
}