using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int dialogueLineID = 1;

    public void UpdateDialogueLineID(int dialogueLineID)
    {
        this.dialogueLineID = dialogueLineID;
    }
    public void TriggerDialogue()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        dm.StartDialogue(dialogueLineID);
        Debug.Log(dm.name);
    }
}
