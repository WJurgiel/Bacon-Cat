using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlyContainer : MonoBehaviour
{
    private Light2D light;

    [SerializeField] private int containerCapacity = 5;

    [SerializeField] private int outerLightRadiusAdder = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light2D>();
        UpdateContainerLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            containerCapacity++;
            UpdateContainerLight();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            containerCapacity--;
            UpdateContainerLight();
        }
    }

    public void UpdateContainerLight()
    {
        light.pointLightInnerRadius = containerCapacity;
        light.pointLightOuterRadius = containerCapacity +outerLightRadiusAdder;
    }
    
}
