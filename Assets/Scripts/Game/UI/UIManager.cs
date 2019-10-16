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

        public void SetTextPanel(string text){
            _canvas.TextPanel.SetText(text);
        }
        
        public static UIManager Instance(){
            if (_manager == null){
                _manager = new UIManager();
            }

            return _manager;
        }
    }
}