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
    public GameObject dialogueCanvas;
    private Queue<DialogueLine> sentences;
    public bool isDialogueActive = false;
    private bool isCorutineActive= false;
    private DialogueLine sentence;
    private DialogueData dialogueData;
    [SerializeField] private float timeBetweenLetter = 0.01f;
    [SerializeField] private string[] filePaths = new string[3];
    [SerializeField]private int CurrentFileIndex = 0;
    private void Awake()
    {
        SetCurrentFileIndex(0);
    }

    void Start()
    {
        sentences = new Queue<DialogueLine>();
    }

    void Update()
    {
        if (isDialogueActive) ChangeSentence();
        
    }

    public void SetCurrentFileIndex(int fileIndex)
    {
        CurrentFileIndex = fileIndex;
        readFromFile();
    }
    private void readFromFile()
    {
        string filePath = Application.dataPath + $"/Dialogues/{filePaths[CurrentFileIndex]}.json";
        // string filePath = Application.dataPath + "/Dialogues/tutorial.json";
        
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
        
        dialogueCanvas.SetActive(true);
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
                yield return new WaitForSeconds(timeBetweenLetter);
            }
            isCorutineActive = false;
    }


    void EndDialogue()
    {
        StartCoroutine(ChangeDialogueActive());
        dialogueCanvas.SetActive(false);
    }
    
    IEnumerator ChangeDialogueActive()
    {
        yield return new WaitForSeconds(timeBetweenLetter);
        isDialogueActive = false;
    }
}
