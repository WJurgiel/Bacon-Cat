using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int id;
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(id);
    }
}
