using UnityEngine;

public class Firecamp : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float range;
    private bool isPlayerInRange;
    [SerializeField] public GameObject UserHint;
    private SanitySystem sanitySystem;
    void Start()
    {
        isPlayerInRange = false;
        sanitySystem  =player.gameObject.GetComponent<SanitySystem>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= range)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                UserHint.SetActive(true);
            }
            
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                UserHint.SetActive(false);
            }
            
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            sanitySystem.FireplaceMeditate();
        }
    }
}
