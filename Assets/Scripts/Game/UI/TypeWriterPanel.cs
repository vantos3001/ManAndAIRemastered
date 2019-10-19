using UnityEngine;

namespace Game.UI
{
    public class TypeWriterPanel : Panel
    {

        [SerializeField] private TypeWriterEffect _typeWriterEffect;

        public bool IsEffectPlayed => _typeWriterEffect.IsPlayed;

        public override void SetText(string text){
            _typeWriterEffect.SetText(text);
        }

        public void SkipEffect(){
            _typeWriterEffect.SkipEffect();
        }
    }
}