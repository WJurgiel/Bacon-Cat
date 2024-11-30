using System.Collections;
using TMPro;
using UnityEngine;

public class BackgroundAndSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject catSprite;
    [SerializeField] private Sprite fallingCatSprite;
    [SerializeField] private TextMeshProUGUI lyricsText;
    [SerializeField] private string triggerLine = "ZACZYNAL SPADAC I KRZYCZAL TAK:";
    [SerializeField] private float backgroundSpeed = 2.0f;

    private bool isTriggered = false;

    private void Update()
    {
        if (isTriggered)
        {
            background.transform.Translate(Vector3.up * backgroundSpeed * Time.deltaTime);
            ChangeSprite();

        }
    }

    public void CheckLyrics(string currentLine)
    {
        if (!isTriggered && currentLine.ToUpper().Contains(triggerLine))
        {
            isTriggered = true;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (catSprite != null && fallingCatSprite != null)
        {
            catSprite.GetComponent<SpriteRenderer>().sprite = fallingCatSprite;
        }
    }
}
