using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.0f;
    [SerializeField] private float resetPosition = -10.0f;
    [SerializeField] private float startPosition = 10.0f; 

    void Update()
    {
        // Przesuwanie tla w lewo
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}
