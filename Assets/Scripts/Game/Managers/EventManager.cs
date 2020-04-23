using System;
using Game.Dialogue;

public static class EventManager
{
    public static Action<DialogueNode> DialoguePhraseChanged;


    public static void HandleDialoguePhraseChanged(DialogueNode node)
    {
        DialoguePhraseChanged?.Invoke(node);
    }
}
