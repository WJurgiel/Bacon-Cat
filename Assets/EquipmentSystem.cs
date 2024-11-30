using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSystem : MonoBehaviour
{
    //Lord forgive me for the hardcoding I'm about to perform.
    
    [SerializeField] private GameObject equipmentPanel;
    [SerializeField] private int maxFireFlies = 10;
    [SerializeField] private int currentFireFlies;
    
    [SerializeField] TMP_Text FireFliesText;
    List<bool> PickedUpItems = new List<bool>();
    [SerializeField] List<GameObject> ItemImages = new List<GameObject>();

    private string[] ItemDescription =
    {
        "Moje zrodlo swiatla, lepiej zebym uzywal je z rozwaga",
        "Dzieki tej kuli mocy moge pokonywac przeciwnikow",
        "Bekon",
        "Kocia Lapa"
    };
    void Start()
    {
        InitializeEquipmentPanel();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleEquipmentPanel();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GiveOrb();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GiveBacon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GivePaw();
        }
    }

    public GameObject GetPanel()
    {
        return equipmentPanel;
    }

    public int GetFireFlies()
    {
        return currentFireFlies;
    }
    private void InitializeEquipmentPanel()
    {
        PickedUpItems.Add(false);
        PickedUpItems.Add(false);
        PickedUpItems.Add(false);
        PickedUpItems.Add(false);
    }
    private void ToggleEquipmentPanel()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
        {
            equipmentPanel.SetActive((!equipmentPanel.activeSelf));
        }
    }
/// <summary>
/// Call when picking up the Item
/// </summary>
    private void UpdatePanel()
    {
        FireFliesText.text = currentFireFlies.ToString() + "/" + maxFireFlies;
        
    }

    public void AddFirefly()
    {
        currentFireFlies++;
        UpdatePanel();
    }

    public void UseFirefly()
    {
        currentFireFlies--;
        UpdatePanel();
    }

    public void GiveOrb()
    {
        PickedUpItems[(int)InventoryItems.ORB] = true;
        ItemImages[(int)InventoryItems.ORB].SetActive(true);
    }

    public void GiveBacon()
    {
        PickedUpItems[(int)InventoryItems.BACON] = true;
        ItemImages[(int)InventoryItems.BACON].SetActive(true);
    }

    public void GivePaw()
    {
        PickedUpItems[(int)InventoryItems.PAW] = true;
        ItemImages[(int)InventoryItems.PAW].SetActive(true);
    }
    
}
