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

        if (other.transform.CompareTag("d1"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(1);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d2"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(2);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d3"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(3);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d4"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(4);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d5"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(5);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d6"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(6);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("d8"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(8);
            other.gameObject.SetActive(false);
        }

        if (other.transform.CompareTag("d9"))
        {
            other.gameObject.GetComponent<dtrigger>().StartDialogue(9);
            other.gameObject.SetActive(false);
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
