using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int id;
    
    public void TriggerDialogue()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        dm.StartDialogue(id);
        Debug.Log(dm.name);
    }
}
