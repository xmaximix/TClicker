using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyHealth 
{
    [SerializeField] public int healthPoints;
    public void TakeDamage(Enemy enemy, int amount)
    {
        healthPoints -= amount;

        if (healthPoints <= 0)
        {
            enemy.Die();
        }
    }
}
