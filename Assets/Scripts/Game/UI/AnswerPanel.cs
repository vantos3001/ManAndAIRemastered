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

        public void UpdateView(DialogueNode dialogueNode)
        {
            IsHasAnswers = dialogueNode.IsHasAnswers();
            
            if (IsHasAnswers)
            {
                var answerCount = dialogueNode.AnswerCount();
                for (int i = 0; i < answerCount; i++)
                {
                    var currentAnswerButton = _answerButtons[i];
                    currentAnswerButton.SetActive(true);
                    currentAnswerButton.SetText(dialogueNode.GetAnswerTextById(i));
                }
            }
            else
            {
                gameObject.SetActive(false);

                foreach (var answerButton in _answerButtons)
                {
                    answerButton.SetActive(false);
                }
            }
        }

        public bool IsHasAnswers { get; private set; }

        public void Load()
        {
            for (int i = 0; i < _answerButtons.Count; i++)
            {
                _answerButtons[i].SetAnswerId(i);
                _answerButtons[i].OnButtonClicked += NotifyAnswerButtonClicked;
            }

            EventManager.TypeWriterEffectEnded += OnTypeWriterEffectEnded;
        }

        private void NotifyAnswerButtonClicked(int answerId)
        {
            AnswerButtonClicked?.Invoke(answerId);
        }

        private void OnTypeWriterEffectEnded()
        {
            if (IsHasAnswers)
            {
                gameObject.SetActive(true);
            }
        }
    }
}