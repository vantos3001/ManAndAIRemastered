using System;
using Game.Dialogue;
using Game.UI;
using UnityEngine;

public class UIDialogueWindow : MonoBehaviour
{
    public TypeWriterPanel TextPanel;
    public AnswerPanel AnswerPanel;

    private UIManager _uiManager;

    private void Awake()
    {
        _uiManager = UIManager.Instance();
        
        EventManager.DialoguePhraseChanged += UpdateView;
        EventManager.OnAnswerButtonClicked += OnAnswerButtonClicked;
        
        AnswerPanel.AnswerButtonClicked += NotifyAnswerButtonClicked;
    }
    
    public void SetContent(DialogueNode node)
    {
        UpdateView(node);
    }
    
    private void HandleMouseLeftClick()
    {
        if(!IsAnswerPanelOpened())
            if (TextPanel.IsWaitForClick || IsHideTextPanel())
            {
                ChangePhrase();
            }
    }
    
    private void ChangePhrase(){
        DialogueManager.Instance().NextDialoguePhrase();
    }
    private void UpdateView(DialogueNode node)
    {
        UpdateTextPanel(node);
        UpdateAnswerPanel(node);

        var newBackground = node.GetNewBackground();
        if (!string.IsNullOrEmpty(newBackground)){
            _uiManager.SetBackground(newBackground);
        }
    }
    
    private void ShowTextPanel(){
        var textPanelGO = TextPanel.gameObject;
        if (!textPanelGO.activeSelf){
            TextPanel.gameObject.SetActive(true);
        }
    }
    
    private void NotifyAnswerButtonClicked(int answerId){
        EventManager.HandleOnAnswerButtonClicked(answerId);
    }
    
    private bool IsHideTextPanel()
    {
        return !TextPanel.isActiveAndEnabled;
    }
    
    private void HideTextPanel(){
        TextPanel.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseLeftClick();
        }
    }
    
    private void ShowAnswerPanel(DialogueNode dialogueNode){
        AnswerPanel.gameObject.SetActive(true);
        AnswerPanel.UpdateButtons(dialogueNode);
    }

    private void HideAnswerPanel(){
        AnswerPanel.gameObject.SetActive(false);
    }

    private bool IsAnswerPanelOpened(){
        return AnswerPanel.gameObject.activeSelf;
    }
    
    private void UpdateTextPanel(DialogueNode dialogueNode){           
        var isHideTextPanel = dialogueNode.IsHideText();
        if (isHideTextPanel){
            HideTextPanel();
        }
        else{
            ShowTextPanel();
                
            var textPanel = TextPanel;

            if (!textPanel.IsEffectPlayed){
                textPanel.SetText(dialogueNode.GetDialogueText());
            }
        }
    }
    
    private void UpdateAnswerPanel(DialogueNode dialogueNode){
        if (dialogueNode.IsHasAnswers()){
            ShowAnswerPanel(dialogueNode);
        }
        else{
            HideAnswerPanel();
        }
    }
    
    private void ChangePhraseByAnswer(int answerId){
        var dialogueNode = DialogueManager.Instance().NextDialoguePhraseByAnswerId(answerId);
        UIManager.Instance().UpdateDialogueWindow(dialogueNode);
    }

    private void OnAnswerButtonClicked(int answerId){
        ChangePhraseByAnswer(answerId);
    }
}
