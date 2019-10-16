using Game.Tools;
using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueSystem
    {
        private const string TEST_ASSET_PATH = "Texts/test_phrases";
        private const string MAIN_TEXT_ASSET_PATH = "Texts/main";
        
        private TextAsset _asset;

        private int _currentPhrase = 0;
        private DialogueNode _currentDialogueNode;

        public DialogueNode CurrentDialogueNode => _currentDialogueNode;

        private DialogueSettings _dialogueSettings;

        public void Load(){
            _asset = Resources.Load<TextAsset>(TEST_ASSET_PATH);
            _dialogueSettings = DialogueSettings.Load(_asset);
        }

        public void StartDialogue(){
            _currentPhrase = 0;
            
            var currentNode = _dialogueSettings.Nodes[_currentPhrase];
            _currentDialogueNode = new DialogueNode(currentNode);
        }

        public void Next(){
            _currentPhrase++;
            var nodeLength = DialogueTextLength();
            
            if ( nodeLength <= _currentPhrase){
                _currentPhrase = nodeLength - 1;
                Debug.LogWarning("Dialogue text ended");
            }

            var currentNode = _dialogueSettings.Nodes[_currentPhrase];
            _currentDialogueNode = new DialogueNode(currentNode);
        }

        private int DialogueTextLength(){
            return _dialogueSettings.Nodes.Length;
        }
    }
    
    public class DialogueNode
    {
        
        private Node _node;

        public DialogueNode(Node node){
            _node = node;
        }

        public bool IsHasAnswers(){
            return _node.answers != null;
        }

        public string GetDialogueText(){
            return _node.text;
        }

        public int AnswerCount(){
            return _node.answers.Length;
        }

        public string GetAnswerTextById(int answerId){
            return _node.answers[answerId].text;
        }

        public string GetNewBackground(){
            return _node.newBackground;
        }
    }
}