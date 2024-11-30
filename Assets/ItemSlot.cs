using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(3, 10), SerializeField] private string itemDescription; 
    [SerializeField] private TMP_Text itemDescriptionText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemDescription == null) return;
        
        Debug.Log(itemDescriptionText);
        itemDescriptionText.text = itemDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemDescription == null) return;
        itemDescriptionText.text = "";
    }
    
    
}
