using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    FireFlyContainer fireFlyContainer;
    EquipmentSystem equipmentSystem;
    SanitySystem sanitySystem;
    MoralitySystem moralitySystem;
    [SerializeField] private GameObject goodEndingPanel;
    [SerializeField] private GameObject badEndingPanel;
    void Start()
    {
        fireFlyContainer = FindObjectOfType<FireFlyContainer>();
        equipmentSystem = FindObjectOfType<EquipmentSystem>();
        sanitySystem = FindObjectOfType<SanitySystem>();
        moralitySystem = FindObjectOfType<MoralitySystem>();
        
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

        if (other.transform.CompareTag("Pouch"))
        {
            Destroy(other.gameObject);
            equipmentSystem.GivePouch();
        }

        if (other.transform.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            equipmentSystem.GiveKey();
        }
        if (other.transform.CompareTag("SpellBook"))
        {
            Destroy(other.gameObject);
            equipmentSystem.GiveOrb();
        }

        if (other.transform.CompareTag("EndGame"))
        {
            Debug.Log("Koniec");
            if (moralitySystem.GetMoralityPoints() >= 2)
            {
                goodEndingPanel.SetActive(true);
                Debug.Log(goodEndingPanel);
            }
            else
            {
                badEndingPanel.SetActive(true);
            }
        }
    }
}
