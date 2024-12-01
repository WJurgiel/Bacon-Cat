using System;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour
{
    public GameObject manager;
    private bool wasActivated = false;
    static private int id = 1;
    private void Awake()
    {
        manager= GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(wasActivated);
        if (!wasActivated)
        
            
            manager.GetComponent<DialogueManager>().StartDialogue(id);
            wasActivated = true;
        }
    }
}
