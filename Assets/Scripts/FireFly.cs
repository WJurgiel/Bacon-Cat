using System.Collections;
using UnityEngine;

public class FireFly : MonoBehaviour
{
    [SerializeField] private float animationOffset = 0.5f;
    [SerializeField] private float timeOfAnimation = 3f;
    private float currentTime;

    void Start()
    {
        StartCoroutine(AnimateFireFly());
    }

    void Update()
    {
        
    }
    private IEnumerator AnimateFireFly()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPosition =  new Vector3(startPos.x, startPos.y + animationOffset, startPos.z);
        while (true)
        {
            
            // Animate towards the target position
            yield return SmoothMove(transform.position, targetPosition, timeOfAnimation);

            // Swap positions
            (startPos, targetPosition) = (targetPosition, startPos);
        }
    }

    private IEnumerator SmoothMove(Vector3 from, Vector3 to, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Snap to the final position to avoid rounding errors
        transform.position = to;
    }
}
