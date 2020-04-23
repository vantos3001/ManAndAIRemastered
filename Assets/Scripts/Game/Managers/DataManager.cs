using UnityEngine;

namespace Game
{
    public static class DataManager
    {
        
        
        public static Sprite GetSpriteBackground(string spriteName){
            var sprite = Resources.Load<Sprite>($"Images/{spriteName}");

            if (sprite == null){
                Debug.LogError("sprite = " + spriteName + " is not found");
            }
            
            return sprite;
        }

        public static AudioClip GetMusic(string musicName)
        {
            var music = Resources.Load<AudioClip>($"Audio/Music/{musicName}");

            if (music == null){
                Debug.LogError("music = " + musicName + " is not found");
            }
            
            return music;
        }
        
        public static AudioClip GetSound(string soundName)
        {
            var sound = Resources.Load<AudioClip>($"Audio/Sounds/{soundName}");

            if (sound == null){
                Debug.LogError("sound = " + soundName + " is not found");
            }
            
            return sound;
        }
    }
}