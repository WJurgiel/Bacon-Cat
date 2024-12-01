using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
