using Unity.VisualScripting;
using UnityEngine;

public class dialogue1 : MonoBehaviour
{
    public GameObject manager;
    private bool wasActivated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!wasActivated)
        {
            manager.GetComponent<DialogueManager>().StartDialogue(1);
            wasActivated = true;
        }
    }
}
