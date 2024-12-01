using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    FireFlyContainer fireFlyContainer;
    EquipmentSystem equipmentSystem;
    SanitySystem sanitySystem;
    void Start()
    {
        fireFlyContainer = FindObjectOfType<FireFlyContainer>();
        equipmentSystem = FindObjectOfType<EquipmentSystem>();
        sanitySystem = FindObjectOfType<SanitySystem>();
        
        Debug.Log(fireFlyContainer);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Firefly"))
        {
            equipmentSystem.AddFirefly();
            Destroy(other.gameObject);
            
        }

        if (other.transform.CompareTag("Bacon"))
        {
            sanitySystem.RegainSanity();
            Destroy(other.gameObject);
        }
    }
}
