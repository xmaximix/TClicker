using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Rotator rotator;
    private Vector3 defaultRotationSpeed;

    private const int maxEnemies = 10;
    private int currentEnemies = 0;
    private int killedEnemies = 0;

    private void Awake()
    {
        EventManager.OnEnemySpawned.AddListener(IncreaseEnemiesCount);
        EventManager.OnEnemyKilled.AddListener(InvokeEnemyKilled);
        EventManager.OnGameFinished.AddListener(SaveRecords);
        
        Timer.ResetTimer();
    }

    private void Start()
    {    
        defaultRotationSpeed = rotator.GetRotationSpeed();
    }

    private void Update()
    {
        Timer.CountTime();
    }

    private void InvokeEnemyKilled()
    {
        DecreaseEnemiesCount();
        IncreaseKilledEnemies();
        IncreaseRotationSpeed();
    }

    private void SaveRecords()
    {
        if (killedEnemies > PlayerPrefs.GetInt(RecordsKeys.maxKillsKey, 0))
        {
            PlayerPrefs.SetInt(RecordsKeys.maxKillsKey, killedEnemies);
        }

        if (Timer.GetPlayTime() > PlayerPrefs.GetFloat(RecordsKeys.maxTimeKey, 0))
        {
            PlayerPrefs.SetInt(RecordsKeys.maxTimeKey, (int)Timer.GetPlayTime());
        }

        PlayerPrefs.SetInt(RecordsKeys.totalKillsKey, PlayerPrefs.GetInt(RecordsKeys.totalKillsKey) + killedEnemies);
    }

    private void IncreaseRotationSpeed()
    {
        rotator.SetRotationSpeed(rotator.GetRotationSpeed() + defaultRotationSpeed * Timer.GetPlayTime() / 2 / 100);
    }

    private void IncreaseEnemiesCount()
    {
        currentEnemies++;    

        if (currentEnemies >= maxEnemies)
        {
            EventManager.SendGameFinished();
        }
    }

    private void DecreaseEnemiesCount()
    {
        currentEnemies--;
    }

    private void IncreaseKilledEnemies()
    {
        killedEnemies++;
    }

    public int GetCurrentEnemies()
    {
        return currentEnemies;
    }

    public int GetMaxEnemies()
    {
        return maxEnemies;
    }

    public int GetKilledEnemies()
    {
        return killedEnemies;
    }
}
