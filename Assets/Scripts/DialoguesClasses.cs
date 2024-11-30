using System;
using System.Collections.Generic;

[Serializable]
public class DialogueLine
{
    public string character;
    public string text;
}

[Serializable]
public class DialogueSequence
{
    public int id;
    public List<DialogueLine> conversation;
}

[Serializable]
public class DialogueData
{
    public List<DialogueSequence> dialogSequences;
}