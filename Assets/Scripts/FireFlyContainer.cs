using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlyContainer : MonoBehaviour
{
    private EquipmentSystem equipmentSystem;
    private Light2D light;

    [SerializeField] private int containerCapacity = 5;

    [SerializeField] private int outerLightRadiusAdder = 3;
    [SerializeField] private float timeBetweenConsuming = 5f;
    void Start()
    {
        light = GetComponent<Light2D>();
        equipmentSystem = FindObjectOfType<EquipmentSystem>();
        
        UpdateContainerLight();
        StartCoroutine(RemoveFireFlyFromContainer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AddFireFlyToContainer();
        }
    }

    public void UpdateContainerLight()
    {
        light.pointLightInnerRadius = containerCapacity;
        light.pointLightOuterRadius = containerCapacity +outerLightRadiusAdder;
    }

    public void AddFireFlyToContainer()
    {
        if (equipmentSystem.GetFireFlies() > 0)
        {
            containerCapacity++;
            equipmentSystem.UseFirefly();
            UpdateContainerLight();
        }
        else
        {
            // komunikat że nie mam wystarczająco fireflyów
            Debug.Log("Ni mom gwiezdnych roboków");
        }
        
    }

    public void DecreaseLight()
    {
        containerCapacity--;
        UpdateContainerLight();
    }

    private IEnumerator RemoveFireFlyFromContainer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenConsuming);
            DecreaseLight();
        }
    }
    
    
}
