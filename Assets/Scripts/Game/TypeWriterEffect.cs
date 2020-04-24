using System;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    [TextArea] private string _text;
    public float CharacterInterval;

    private string _partialText;
    private float _cumulativeDeltaTime;

   [SerializeField] private TextMeshProUGUI _label;

    private bool _isPlayed;
    public bool IsPlayed => _isPlayed;

    private bool _skipByMouse;

    private bool _isFirstFramePassed;

    public Action DialoguePhraseEnded;

    private void Update()
    {
        if (_isPlayed)
        {
            UpdateEffect();
        }
    }

    private void UpdateEffect()
    {
        _cumulativeDeltaTime += Time.deltaTime;

        while (_cumulativeDeltaTime >= CharacterInterval && _partialText.Length != _text.Length)
        {
            _partialText += _text[_partialText.Length];
            _cumulativeDeltaTime -= CharacterInterval;
        }

        _label.text = _partialText;

        if (_partialText.Length == _text.Length)
        {
            StopEffect();
        }

        if (_skipByMouse)
        {
            if (_isFirstFramePassed && Input.GetMouseButtonDown(0))
            {
                SkipEffect();
            }
            else
            {
                _isFirstFramePassed = true;
            }
        }
    }

    private void Clear()
    {
        _label.text = "";
        _partialText = "";
        _cumulativeDeltaTime = 0;
        _isFirstFramePassed = false;
    }

    public void SetText(string text, bool skipByMouse = false)
    {
        Clear();
        _text = text;
        _skipByMouse = skipByMouse;

        _isPlayed = true;
    }

    private void StopEffect()
    {
        _partialText = _text;
        _label.text = _partialText;

        _isPlayed = false;

        HandleOnEffectEnded();
    }

    private void HandleOnEffectEnded()
    {
        DialoguePhraseEnded?.Invoke();
    }

    public void SkipEffect()
    {
        StopEffect();
    }
}