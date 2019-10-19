using TMPro;
using UnityEngine;

namespace Game
{
    public class TypeWriterEffect : MonoBehaviour
    {
        [TextArea] private string _text;
        public float CharacterInterval;

        private string _partialText;
        private float _cumulativeDeltaTime;

        private TextMeshProUGUI _label;

        private bool _isPlayed;
        public bool IsPlayed => _isPlayed;

        private void Awake(){
            _label = GetComponent<TextMeshProUGUI>();
        }

        private void Start(){
            Clear();
        }

        private void Update(){

            if (_isPlayed){
                UpdateEffect();
            }
        }

        private void UpdateEffect(){
            _cumulativeDeltaTime += Time.deltaTime;

            while (_cumulativeDeltaTime >= CharacterInterval && _partialText.Length != _text.Length){
                _partialText += _text[_partialText.Length];
                _cumulativeDeltaTime -= CharacterInterval;
            }

            _label.text = _partialText;

            if (_partialText.Length == _text.Length){
                _isPlayed = false;
            }
        }

        private void Clear(){
            _partialText = "";
            _cumulativeDeltaTime = 0;
        }

        public void SetText(string text){
            Clear();
            _text = text;

            _isPlayed = true;
        }

        public void SkipEffect(){
            _partialText = _text;
            _label.text = _partialText;

            _isPlayed = false;
        }
    }
}