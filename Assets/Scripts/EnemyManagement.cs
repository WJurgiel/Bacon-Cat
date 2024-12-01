using System;
using UnityEngine;
using System.Collections;

public class EnemyManagement : MonoBehaviour
{
    [SerializeField] private float spawnRange = 13f;
    [SerializeField] private GameObject prefabToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnObjectInRange();
        }
    }
    
    public void SpawnObjectInRange()
    {
        // Losowanie pozycji w promieniu
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * spawnRange;

        // Nowa pozycja to obecna pozycja + przesunięcie
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        // Tworzenie obiektu
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
