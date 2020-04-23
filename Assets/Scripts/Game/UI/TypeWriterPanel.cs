using System;
using Game.Dialogue;
using UnityEngine;

namespace Game.UI
{
    public class TypeWriterPanel : Panel
    {

        [SerializeField] private TypeWriterEffect _typeWriterEffect;

        public bool IsEffectPlayed => _typeWriterEffect.IsPlayed;
        
        private bool _isWaitForClick;
        public bool IsWaitForClick => _isWaitForClick;

        private void Awake()
        {
            _typeWriterEffect.DialoguePhraseEnded += OnDialoguePhraseEnded;
        }

        public void UpdateView(DialogueNode dialogueNode)
        {
            var isHideTextPanel = dialogueNode.IsHideText();
            if (isHideTextPanel){
                gameObject.SetActive(false);
            }
            else{
                gameObject.SetActive(true);
                
                if (!IsEffectPlayed){
                    SetText(dialogueNode.GetDialogueText());
                }
            }
        }
        
        public override void SetText(string text)
        {
            Clear();
            
            _typeWriterEffect.SetText(text , true);
        }
        
        private void Clear()
        {
            _isWaitForClick = false;
        }

        private void OnDialoguePhraseEnded()
        {
            _isWaitForClick = true;
            EventManager.HandleTypeWriterEffectEnded();
        }
    }
}