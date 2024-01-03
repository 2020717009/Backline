using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Olu�turulacak d��man prefab'lar�n�n dizisi
    public int enemiesPerWave = 10; // Her dalga ba��na d��man say�s�
    public float spawnRadius = 5f; // D��manlar�n rastgele konumland�r�laca�� alan�n yar� �ap�
    public float spawnInterval = 2f; // D��man olu�turma aral��� (saniye)

    private float nextSpawnTime;

    
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Belirli aral�klarla d��man olu�tur
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
        // Rastgele bir d��man prefab'� se�
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Rastgele bir a�� se� ve �ember �zerinde konum hesapla
        float angle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * spawnRadius;
        Vector3 spawnWorldPosition = new Vector3(spawnPosition.x, 0f, spawnPosition.y) + transform.position;

        // D��man� olu�tur ve konumland�r
        Instantiate(randomEnemyPrefab, spawnWorldPosition, Quaternion.identity);
    }
}

