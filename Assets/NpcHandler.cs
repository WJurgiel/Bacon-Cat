using DefaultNamespace;
using UnityEngine;

public class NpcHandler : MonoBehaviour
{
    [SerializeField] private int npcId;
    [SerializeField] private float rangeToInteract;
    [SerializeField] private GameObject userHint;
    [SerializeField] private InventoryItems requiredItem;
    [SerializeField] private EquipmentSystem equipmentSystem;
    private bool isPlayerInRange;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        equipmentSystem = FindObjectOfType<EquipmentSystem>();
        isPlayerInRange = false;
    }

    void Update()
    {
       CheckDistance();
       if(isPlayerInRange && Input.GetKeyDown(KeyCode.F)) CheckIfHasItem();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= rangeToInteract)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                userHint.SetActive(true);
            }
            
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                userHint.SetActive(false);
            }
            
        }
    }

    private void CheckIfHasItem()
    {
        if (equipmentSystem.GetPickedUpItems()[(int)requiredItem])
        {
            Debug.Log("Yupiii");
        }
        else
        {
            Debug.Log(">:(");
        }
    }
    
}
