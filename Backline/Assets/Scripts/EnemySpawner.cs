using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Olu�turulacak d��man prefab'lar�n�n dizisi
    public float minSpawnInterval = 1f; // Minimum spawn aral��� (saniye)
    public float maxSpawnInterval = 5f; // Maximum spawn aral��� (saniye)
    public float spawnRadius = 5f; // D��manlar�n rastgele konumland�r�laca�� alan�n yar� �ap�
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        // �lk d��man spawn zaman�n� belirle
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Zaman� kontrol et ve yeni d��man olu�tur
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemy();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval); // Bir sonraki spawn zaman�n� g�ncelle
        }
    }

    void SpawnRandomEnemy()
    {
        // Rastgele bir d��man prefab'� se�
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Rastgele bir konum �ret
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPosition.x, 0f, randomPosition.y) + transform.position;

        // D��man� olu�tur ve konumland�r
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
