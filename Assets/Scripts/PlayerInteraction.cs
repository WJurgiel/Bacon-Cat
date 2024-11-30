using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    FireFlyContainer fireFlyContainer;
    void Start()
    {
        fireFlyContainer = FindObjectOfType<FireFlyContainer>();
        Debug.Log(fireFlyContainer);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Firefly"))
        {
            fireFlyContainer.IncreaseLight();
            Destroy(other.gameObject);
        }
    }
}
