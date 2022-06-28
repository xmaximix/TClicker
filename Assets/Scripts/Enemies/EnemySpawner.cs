using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemiesHolder;

    [SerializeField] Enemy[] enemies;

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    private float defaultMinSpawnTime;
    private float defaultMaxSpawnTime;

    [SerializeField] Collider spawnArea;

    private Vector3 spawnPosition;

    private void Start()
    {
        EventManager.OnFreezeBoosterActivated.AddListener(Freeze);
        EventManager.OnGameFinished.AddListener(StopAllCoroutines);

        defaultMinSpawnTime = minSpawnTime;
        defaultMaxSpawnTime = maxSpawnTime;

        SortEnemiesBySpawnChance();

        StartCoroutine(Spawn());
    }

    private void SortEnemiesBySpawnChance()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < enemies.Length; j++)
            {
                if (enemies[j].spawnChance > enemies[i].spawnChance)
                {
                    var tmp = enemies[j];
                    enemies[j] = enemies[i];
                    enemies[i] = tmp;
                }
            }
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int random = Random.Range(1, 101);

            foreach (Enemy enemy in enemies)
            {
                if (random <= enemy.spawnChance)
                {
                    CalculateRandomPositionInsideSpawnArea();

                    Instantiate(enemy, spawnPosition, Quaternion.identity, enemiesHolder.transform);
                    EventManager.SendEnemySpawned();
                    break;
                }
            }
            DecreaseSpawnTime();
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    private void DecreaseSpawnTime()
    {
        minSpawnTime = defaultMinSpawnTime;
        maxSpawnTime = defaultMaxSpawnTime;
        minSpawnTime -= minSpawnTime * Timer.GetPlayTime() / 2 / 100;
        maxSpawnTime -= maxSpawnTime * Timer.GetPlayTime() / 2 / 100;
    }

    private void CalculateRandomPositionInsideSpawnArea()
    {
        var xPosition = Random.Range(-spawnArea.bounds.size.x / 2, spawnArea.bounds.size.x / 2);
        var yPosition = 0;
        var zPosition = Random.Range(-spawnArea.bounds.size.z / 2, spawnArea.bounds.size.z / 2);

        spawnPosition = new Vector3(xPosition, yPosition, zPosition);
    }

    private void Freeze()
    {
        StopAllCoroutines();
        StartCoroutine(FreezeCoroutine());
    }

    private IEnumerator FreezeCoroutine()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Spawn());
    }

    public Enemy[] GetEnemies()
    {
        return enemies;
    }
}
