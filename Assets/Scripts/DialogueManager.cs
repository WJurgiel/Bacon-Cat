using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Canvas dialogueCanvas;
    private Queue<DialogueLine> sentences;
    public bool isDialogueActive = false;
    private bool isCorutineActive= false;
    private DialogueLine sentence;
    private DialogueData dialogueData;

    private void Awake()
    {
        readFromFile();
    }

    void Start()
    {
        sentences = new Queue<DialogueLine>();
    }

    void Update()
    {
        if (isDialogueActive) ChangeSentence();
        
    }
    private void readFromFile()
    {
        string filePath = Application.dataPath + "/Dialogues/tutorial.json";
        
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            dialogueData = JsonUtility.FromJson<DialogueData>(jsonContent);
        }
        else
        {
            Debug.LogError($"Nie znaleziono pliku JSON pod ścieżką: {filePath}");
        }
    }

    private void ChangeSentence()
    {
        if (Input.anyKeyDown)
        {
            if (isCorutineActive)
            {
                isCorutineActive = false;
                StopAllCoroutines();
                dialogueText.text = sentence.text;
            }
            else
            {
                DisplayNextSentence();
                
            }
        }
    }

    public void StartDialogue(int id)
    {
        DialogueSequence dialogue = dialogueData.dialogSequences.FirstOrDefault(seq => seq.id == id);
        if (dialogue == null)
        {
            Debug.Log("Wykrocozno poza zakres ID");
            return;   
        }
        ;
        isDialogueActive = true;
        sentences.Clear();
        foreach (DialogueLine dialogueLine in dialogue.conversation) sentences.Enqueue(dialogueLine);
        
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
        nameText.text = sentence.character;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(DialogueLine sentence)
    {
        isCorutineActive = true;
            dialogueText.text = "";
            foreach (char letter in sentence.text.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
            isCorutineActive = false;
    }


    void EndDialogue()
    {
        StartCoroutine(ChangeDialogueActive());
        dialogueCanvas.gameObject.SetActive(false);
    }
    
    IEnumerator ChangeDialogueActive()
    {
        yield return null;
        isDialogueActive = false;
    }
}
