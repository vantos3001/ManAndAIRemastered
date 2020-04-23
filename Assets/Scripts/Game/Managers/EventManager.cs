using System;
using Game.Dialogue;

public static class EventManager
{
    public static Action<DialogueNode> DialoguePhraseChanged;

    public static Action TypeWriterEffectEnded;
    
    public static event Action<int> OnAnswerButtonClicked;

    public static Action<string> OnPlayerNameInputEnded;


    public static void HandleDialoguePhraseChanged(DialogueNode node)
    {
        DialoguePhraseChanged?.Invoke(node);
    }
    
    public static void HandleTypeWriterEffectEnded()
    {
        TypeWriterEffectEnded?.Invoke();
    }
    
    public static void HandleOnAnswerButtonClicked(int answerId)
    {
        OnAnswerButtonClicked?.Invoke(answerId);
    }
    
    public static void HandleOnPlayerNameInputEnded(string playerName)
    {
        OnPlayerNameInputEnded?.Invoke(playerName);
    }
}
