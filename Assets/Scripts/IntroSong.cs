using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Mo¿esz u¿yæ TextMeshPro, jeœli wolisz
using System.IO;
using TMPro;

public class IntroSong : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songText; // Pole na komponent UI Text
    [SerializeField] private float lineDisplayDuration = 2.0f; // Czas wyœwietlania ka¿dej linii
    [SerializeField] private string fileName = "introText.json"; // Nazwa pliku JSON w folderze Resources

    private List<string> lyrics = new List<string>();

    void Start()
    {
        LoadLyrics();
        StartCoroutine(DisplayLyrics());
    }

    private void LoadLyrics()
    {
        // Wczytaj plik JSON z Resources
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        if (jsonFile == null)
        {
            Debug.LogError("Nie znaleziono pliku JSON w Resources.");
            return;
        }

        // Parsowanie JSON-a
        SongData songData = JsonUtility.FromJson<SongData>(jsonFile.text);

        // Dodaj linie do listy
        foreach (var verse in songData.verses)
        {
            foreach (var line in verse.line)
            {
                lyrics.Add(line.text);
            }
        }
    }

    private IEnumerator DisplayLyrics()
    {
        // Wyœwietlaj linie po kolei
        foreach (string line in lyrics)
        {
            songText.text = line; // Wyœwietl tekst
            yield return new WaitForSeconds(lineDisplayDuration); // Czekaj okreœlony czas
        }

        songText.text = ""; // Wyczyœæ po zakoñczeniu
    }
}

[System.Serializable]
public class SongData
{
    public List<Verse> verses;
}

[System.Serializable]
public class Verse
{
    public List<Line> line;
}

[System.Serializable]
public class Line
{
    public string text;
}
