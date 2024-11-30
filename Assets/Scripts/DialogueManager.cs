using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Canvas dialogueCanvas;
    private Queue<string> sentences;
    public bool isDialogueActive = false;
    private bool isCorutineActive= false;
    private string sentence;
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (isDialogueActive) ChangeSentence();
        
    }

    private void ChangeSentence()
    {
        if (Input.anyKeyDown)
        {
            if (isCorutineActive)
            {
                isCorutineActive = false;
                StopAllCoroutines();
                dialogueText.text = sentence;
            }
            else
            {
                DisplayNextSentence();
                
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (String sentence in dialogue.sentences) sentences.Enqueue(sentence);
        
        dialogueCanvas.gameObject.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isCorutineActive = true;
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
            isCorutineActive = false;
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueCanvas.gameObject.SetActive(false);
    }
}
