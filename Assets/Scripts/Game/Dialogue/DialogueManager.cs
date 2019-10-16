using System;

namespace Game.Dialogue
{
    public class DialogueManager
    {
        private static DialogueManager _manager;
        private DialogueSystem _dialogueSystem;
        
        public Action<DialogueNode> DialoguePhraseChanged;

        
        private DialogueManager(){
            _dialogueSystem = new DialogueSystem();
        }
        
        public DialogueNode StartDialogue(){
            _dialogueSystem.StartDialogue();

            NotifyDialoguePhraseChanged();
            
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            return currentDialogueNode;
        }

        public DialogueNode NextDialoguePhrase(){
            _dialogueSystem.Next();
            
            NotifyDialoguePhraseChanged();
            
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            return currentDialogueNode;
        }

        private void NotifyDialoguePhraseChanged(){
            var currentDialogueNode = _dialogueSystem.CurrentDialogueNode;
            DialoguePhraseChanged?.Invoke(currentDialogueNode);
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