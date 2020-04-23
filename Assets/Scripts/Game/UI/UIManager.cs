using System;
using Game.Dialogue;
using UnityEngine;

namespace Game.UI
{
    public class UIManager
    {
        private static UIManager _manager;
        private UICanvas _canvas;

        private UIManager(){
            _canvas = GameObject.FindWithTag("Canvas").GetComponent<UICanvas>();
        }

        public void UpdateDialogueWindow(DialogueNode dialogueNode)
        {
            _canvas.DialogueWindow.SetContent(dialogueNode);
        }

        public void SetBackground(string backgroundName){
            var background = DataManager.GetSpriteBackground(backgroundName);
            _canvas.Background.sprite = background;
        }

        public static UIManager Instance(){
            if (_manager == null){
                _manager = new UIManager();
            }

            return _manager;
        }
    }
}