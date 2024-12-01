using System;
using UnityEngine;
using System.Collections;

public class EnemyManagement : MonoBehaviour
{
    [SerializeField] private float spawnRange = 20f;
    [SerializeField] private GameObject prefabToSpawn;

    void Update()
    {
    }
    
    public void SpawnObjectInRange()
    {
        
        // Losowanie kąta w stopniach (0–360)
        float angle = UnityEngine.Random.Range(0f, 360f);

        // Konwersja kąta na radiany
        float radians = angle * Mathf.Deg2Rad;

        // Obliczanie pozycji na obrzeżu koła
        Vector3 edgePosition = new Vector3(
            Mathf.Cos(radians) * spawnRange, // X
            Mathf.Sin(radians) * spawnRange, // Y
            0                                // Z (w przypadku 2D)
        );
        
        // Tworzenie obiektu
        Instantiate(prefabToSpawn, transform.position + edgePosition, Quaternion.identity);
    }
}
