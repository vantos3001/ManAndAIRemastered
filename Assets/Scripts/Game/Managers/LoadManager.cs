using System;
using Game.Dialogue;
using Game.UI;

namespace Game
{
    public class LoadManager
    {
        private static LoadManager _manager;

        public Action LoadFinished;

        public void Load(){
            DialogueManager.Instance().Load();
            UIManager.Instance().Load();
            AudioManager.Load();

            LoadFinished?.Invoke();
        }

        public static LoadManager Instance(){
            if (_manager == null){
                _manager = new LoadManager();
            }

            return _manager;
        }
    }
}