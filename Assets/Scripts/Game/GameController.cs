using Game;
using Game.Dialogue;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Awake()
    {
        LoadManager.Instance().LoadFinished += OnLoadFinished;
        LoadManager.Instance().Load();
    }

    private void OnLoadFinished(){
        DialogueManager.Instance().StartDialogue();
    }
}
