using Game.Dialogue;
using Game.UI;
using UnityEngine;

public class UIDialogueWindow : MonoBehaviour
{
    public TypeWriterPanel TextPanel;
    public AnswerPanel AnswerPanel;

    private void Awake()
    {
        EventManager.DialoguePhraseChanged += UpdateView;
        
        AnswerPanel.AnswerButtonClicked += NotifyAnswerButtonClicked;
    }
    
    public void SetContent(DialogueNode node)
    {
        UpdateView(node);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseLeftClick();
        }
    }
    
    private void UpdateView(DialogueNode node)
    {
        TextPanel.UpdateView(node);
        AnswerPanel.UpdateView(node);

        var newBackground = node.GetNewBackground();
        if (!string.IsNullOrEmpty(newBackground)){
            UIManager.Instance().SetBackground(newBackground);
        }
    }

    private void HandleMouseLeftClick()
    {
        if(!AnswerPanel.IsOpened())
            if (TextPanel.IsWaitForClick || IsHideTextPanel())
            {
                ChangePhrase();
            }
    }
    
    private void ChangePhrase(){
        DialogueManager.Instance().NextDialoguePhrase();
    }
    
    private bool IsHideTextPanel()
    {
        return !TextPanel.isActiveAndEnabled;
    }

    private void NotifyAnswerButtonClicked(int answerId){
        EventManager.HandleOnAnswerButtonClicked(answerId);
    }
}
