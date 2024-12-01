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
    }
}
