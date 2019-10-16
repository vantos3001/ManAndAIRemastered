using Game.UI;
using TMPro;
using UnityEngine;

namespace Game.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        
        //TODO: add answerPanel

        private void Update(){
            if (Input.GetKeyDown(KeyCode.Space)){
                ChangePhrase();
            }
        }

        private void ChangePhrase(){
            var phrase = DialogueManager.Instance().NextDialoguePhrase();
            UIManager.Instance().SetTextPanel(phrase);
        }
    }
}