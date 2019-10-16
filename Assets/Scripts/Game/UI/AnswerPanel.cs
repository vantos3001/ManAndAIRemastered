using System;
using System.Collections.Generic;
using Game.Dialogue;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class AnswerPanel : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private List<UIAnswerButton> _answerButtons;

        public event Action<int> AnswerButtonClicked;
        
        // Start is called before the first frame update
        void Awake(){
            
            for (int i = 0; i < _answerButtons.Count; i++){
                _answerButtons[i].SetAnswerId(i);
                _answerButtons[i].OnButtonClicked += NotifyAnswerButtonClicked;
            }
        }

        public void UpdateButtons(DialogueNode dialogueNode){
            if (dialogueNode.IsHasAnswers()){
                var answerCount = dialogueNode.AnswerCount();
                for (int i = 0; i < answerCount; i++){
                    var currentAnswerButton = _answerButtons[i];
                    currentAnswerButton.SetActive(true);
                    currentAnswerButton.SetText(dialogueNode.GetAnswerTextById(i));
                }
            }
            else{
                foreach (var answerButton in _answerButtons){
                    answerButton.SetActive(false);
                }
            }
        }

        private void NotifyAnswerButtonClicked(int answerId){
            AnswerButtonClicked?.Invoke(answerId);
        }
        
    }
}