using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Oluþturulacak düþman prefab'larýnýn dizisi
    public float minSpawnInterval = 1f; // Minimum spawn aralýðý (saniye)
    public float maxSpawnInterval = 5f; // Maximum spawn aralýðý (saniye)
    public float spawnRadius = 5f; // Düþmanlarýn rastgele konumlandýrýlacaðý alanýn yarý çapý
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        // Ýlk düþman spawn zamanýný belirle
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Zamaný kontrol et ve yeni düþman oluþtur
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemy();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval); // Bir sonraki spawn zamanýný güncelle
        }
    }

    void SpawnRandomEnemy()
    {
        // Rastgele bir düþman prefab'ý seç
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Rastgele bir konum üret
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPosition.x, 0f, randomPosition.y) + transform.position;

        // Düþmaný oluþtur ve konumlandýr
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
