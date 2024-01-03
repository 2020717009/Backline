using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Oluþturulacak düþman prefab'larýnýn dizisi
    public int enemiesPerWave = 10; // Her dalga baþýna düþman sayýsý
    public float spawnRadius = 5f; // Düþmanlarýn rastgele konumlandýrýlacaðý alanýn yarý çapý
    public float spawnInterval = 2f; // Düþman oluþturma aralýðý (saniye)

    private float nextSpawnTime;

    
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Belirli aralýklarla düþman oluþtur
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnRandomEnemy();
        }

        
    }

    void SpawnRandomEnemy()
    {
        // Rastgele bir düþman prefab'ý seç
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Rastgele bir açý seç ve çember üzerinde konum hesapla
        float angle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * spawnRadius;
        Vector3 spawnWorldPosition = new Vector3(spawnPosition.x, 0f, spawnPosition.y) + transform.position;

        // Düþmaný oluþtur ve konumlandýr
        Instantiate(randomEnemyPrefab, spawnWorldPosition, Quaternion.identity);
    }
}

