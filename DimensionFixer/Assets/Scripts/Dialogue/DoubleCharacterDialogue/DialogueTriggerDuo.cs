using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerDuo : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueDuo dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerDuo>().StartDialogue(dialogue);
    }
}
