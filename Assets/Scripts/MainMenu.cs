using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject optionButton;
    [SerializeField] private GameObject eyes;
    [SerializeField] private float moveDistance = 0.5f;
    [SerializeField] private float speed = 2.0f;

    AudioManager audioManager;
    
    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        audioManager=GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync(1);
        audioManager.PlaySfx(audioManager.menuClick);
    }
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        audioManager.PlaySfx(audioManager.menuClick);
    }
    public void ShowSettings()
    {
        Color currentColor = optionButton.GetComponent<Image>().color ;
        
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            optionButton.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
            targetPosition = eyes.transform.position + new Vector3(0, moveDistance, 0);
            
            audioManager.PlaySfx(audioManager.menuClick);
        }
        else
        {
            settingsPanel.SetActive(true);
            optionButton.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 100);
            targetPosition = eyes.transform.position - new Vector3(0, moveDistance, 0);
            
            audioManager.PlaySfx(audioManager.menuClick);
        }

        StartCoroutine(EyesTransition());

    }

    public void QuitGame()
    {
        Application.Quit();
        audioManager.PlaySfx(audioManager.menuClick);
    }

    private IEnumerator EyesTransition()
    {
        float elapsedTime = 0f;
        originalPosition = eyes.transform.position;
        while (elapsedTime < speed)
        {
            eyes.transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        eyes.transform.position = targetPosition;
    }
}
