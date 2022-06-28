using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static UnityEvent OnEnemySpawned = new UnityEvent();
    public static UnityEvent OnGameFinished = new UnityEvent();
    public static UnityEvent OnFreezeBoosterActivated = new UnityEvent();
    public static UnityEvent OnDestroBoosterActivated = new UnityEvent();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    public static void SendEnemySpawned()
    {
        OnEnemySpawned.Invoke();
    }

    public static void SendGameFinished()
    {
        OnGameFinished.Invoke();
    }
    
    public static void SendFreezeActivated()
    {
        OnFreezeBoosterActivated.Invoke();
    }

    public static void SendDestroActivated()
    {
        OnDestroBoosterActivated.Invoke();
    }
}
