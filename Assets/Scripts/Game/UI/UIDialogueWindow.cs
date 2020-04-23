using Game.Dialogue;
using Game.UI;
using UnityEngine;

public class UIDialogueWindow : MonoBehaviour
{
    public TypeWriterPanel TextPanel;
    public AnswerPanel AnswerPanel;
    public UIInputField UiInputField;

    public void SetContent(DialogueNode node)
    {
        UpdateView(node);
    }

    public void Load()
    {
        AnswerPanel.Load();
        
        EventManager.DialoguePhraseChanged += UpdateView;
        
        AnswerPanel.AnswerButtonClicked += NotifyAnswerButtonClicked;
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
        UiInputField.UpdateView(node);

        var newBackground = node.GetNewBackground();
        if (!string.IsNullOrEmpty(newBackground)){
            UIManager.Instance().SetBackground(newBackground);
        }
    }

    private void HandleMouseLeftClick()
    {
        if(!AnswerPanel.IsHasAnswers && !UiInputField.IsHaveInput)
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
