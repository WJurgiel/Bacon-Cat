using DefaultNamespace;
using UnityEngine;

public class NpcHandler : MonoBehaviour
{
    [SerializeField] private int npcId;
    [SerializeField] private float rangeToInteract;
    [SerializeField] private GameObject userHint;
    [SerializeField] private InventoryItems requiredItem;
    [SerializeField] private EquipmentSystem equipmentSystem;
    [SerializeField] private MoralitySystem moralitySystem;
    private DialogueManager dialogueManager;
    private DialogueTrigger dialogueTrigger;
    private bool isPlayerInRange;
    private Transform player;
    private int dialogueLineID = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        equipmentSystem = FindObjectOfType<EquipmentSystem>();
        moralitySystem = FindObjectOfType<MoralitySystem>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        isPlayerInRange = false;
    }

    void Update()
    {
       CheckDistance();
       if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
       {
           CheckIfHasItem();
           dialogueManager.SetCurrentFileIndex(npcId);
           dialogueTrigger.UpdateDialogueLineID(dialogueLineID);
           dialogueTrigger.TriggerDialogue();
       }
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
            dialogueLineID = 2;
            moralitySystem.addMoralPoint();
        }
    }
    
}
 