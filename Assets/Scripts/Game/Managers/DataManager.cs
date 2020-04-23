using UnityEngine;

namespace Game
{
    public class DataManager
    {
        private static DataManager _manager;
        
        public static DataManager Instance(){
            if (_manager == null){
                _manager = new DataManager();
            }

            return _manager;
        }

        public static Sprite GetSpriteBackground(string spriteName){
            var sprite = Resources.Load<Sprite>($"Images/{spriteName}");

            if (sprite == null){
                Debug.LogError("sprite = " + spriteName + " is not found");
            }
            
            return sprite;
        }
    }
}