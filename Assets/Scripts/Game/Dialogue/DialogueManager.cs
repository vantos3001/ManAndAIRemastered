using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueManager
    {
        private static DialogueManager _manager;
        private DialogueSystem _dialogueSystem;
        
        
        private DialogueManager(){
            _dialogueSystem = new DialogueSystem();
        }
        
        public DialogueNode StartDialogue(){
            _dialogueSystem.StartDialogue();

            NotifyDialoguePhraseChanged();
            
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            return currentDialogueNode;
        }
        
        public DialogueNode NextDialoguePhraseByAnswerId(int answerId){
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