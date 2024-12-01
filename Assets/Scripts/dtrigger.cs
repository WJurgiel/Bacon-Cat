using UnityEngine;

public class dtrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject dialogManager;
    void Start()
    {
        dialogManager = GameObject.FindWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(int id)
    {
        dialogManager.GetComponent<DialogueManager>().StartDialogue(id);
    }
}
