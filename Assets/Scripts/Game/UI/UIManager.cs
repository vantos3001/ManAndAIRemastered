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

        public void SetBackground(string backgroundName){
            var background = DataManager.GetSpriteBackground(backgroundName);
            _canvas.Background.sprite = background;
        }

        public void HideTextPanel(){
            _canvas.TextPanel.gameObject.SetActive(false);
        }

        public void ShowTextPanel(){
            var textPanelGO = _canvas.TextPanel.gameObject;
            if (!textPanelGO.activeSelf){
                _canvas.TextPanel.gameObject.SetActive(true);
            }
        }
        
        public static UIManager Instance(){
            if (_manager == null){
                _manager = new UIManager();
            }

            return _manager;
        }
    }
}