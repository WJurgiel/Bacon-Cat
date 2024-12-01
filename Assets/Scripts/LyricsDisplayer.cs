using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LyricsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lyricsText;
    [SerializeField] private BackgroundAndSpriteController controller;
    [SerializeField] private float displayDelay = 3.0f;
    [SerializeField] private GameObject blackOverlay;
    [SerializeField] private string endSceneName = "MainMenu";
    [SerializeField] private float fadeDuration = 2.0f;
    [SerializeField] private float blackOverlayDuration = 2.0f;
    
    AudioManagerIntro audioManagerIntro;

    private string[] lyrics = {
        "KOSMOSY PRZEMIERZA, NA PLASTERKU BEKONU",
        "MILIONY LAT SWIETLNYCH W ODLEGLOSCI OD DOMU",
        "W SWOIM KOMBINEZONIE, KRYJE SWOJE WSZYSTKIE BRONIE",
        "PRZEZ KOSMOS LECI, PRZEZ KOSMOS LECI",
        "LECZ KOT BYL Z AMERYKI POMYLIL WSZYSTKIE GUZIKI",
        "ZACZYNAL SPADAC I KRZYCZAL TAK:",
        "I'M GOING DOWN, DOWN, DOWN",
        "I'M GOING, I'M GOING, I'M GOING DOWN",
        "I'M GOING DOWN, DOWN, DOWN"
    };

    private int currentLineIndex = 0;
    private bool isSkipping = false;

    private void Awake()
    {
        audioManagerIntro = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerIntro>();

        if (audioManagerIntro != null)
        {
            // Ustaw zapętlanie i odtwórz dźwięk za pomocą AudioManagerIntro
            audioManagerIntro.PlayLoopedSound();
        }
    }

    private void Start()
    {
        if (blackOverlay != null)
        {
            blackOverlay.SetActive(false);
        }

        StartCoroutine(DisplayLyrics());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSkipping)
        {
            isSkipping = true;
            SkipIntro();
        }
    }

    private IEnumerator DisplayLyrics()
    {
        while (currentLineIndex < lyrics.Length)
        {
            string currentLine = lyrics[currentLineIndex];
            lyricsText.text = currentLine;

            controller.CheckLyrics(currentLine);

            currentLineIndex++;
            yield return new WaitForSeconds(displayDelay);
        }

        EndSong();
    }

    private void EndSong()
    {
        if (blackOverlay != null)
        {
            blackOverlay.SetActive(true);
            StartCoroutine(FadeInBlackOverlay());
        }

        StartCoroutine(ChangeSceneAfterDelay(2f));
    }

    private IEnumerator FadeInBlackOverlay()
    {
        CanvasGroup canvasGroup = blackOverlay.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = blackOverlay.AddComponent<CanvasGroup>();
        }

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(blackOverlayDuration);

        StartCoroutine(ChangeSceneAfterDelay(1f));

    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

    private void SkipIntro()
    {
        // Natychmiast aktywuj czarne t�o i przejd� do sceny ko�cowej
        if (blackOverlay != null)
        {
            blackOverlay.SetActive(true);
            CanvasGroup canvasGroup = blackOverlay.GetComponent<CanvasGroup>();

            if (canvasGroup == null)
            {
                canvasGroup = blackOverlay.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 1f; // Ustaw pe�n� widoczno�� czarnego t�a
        }

        SceneManager.LoadScene(endSceneName);
    }


}
