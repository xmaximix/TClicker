using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int spawnChance;

    [SerializeField] HorizontalMovement movement;
    [SerializeField] EnemyHealth health;
    [SerializeField] EnemyAnimations animations;

    private void Start()
    {
        EventManager.OnDestroBoosterActivated.AddListener(Die);

        AdjustHeight();
        
        animations.defaultScale = transform.localScale;
        StartCoroutine(animations.Spawn(transform));

        IncreaseStatsOverTime();

        movement.SetTransform(transform);
        movement.SetArena(transform.parent);
        StartCoroutine(RandomizeMovement());
    }

    private void IncreaseStatsOverTime()
    {
        movement.speed += movement.speed * Timer.GetPlayTime() / 100;
        health.healthPoints += health.healthPoints * (int)Timer.GetPlayTime() / 100;
    }

    private void AdjustHeight()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localScale.y / 2, transform.localPosition.z);
    }

    private void Update()
    {
        movement.Move();
    }

    private void OnMouseDown()
    {
        health.TakeDamage(this, 1);
        movement.ChangeDirectionRandomly();
        StartCoroutine(animations.Hit(transform));
    }

    private IEnumerator RandomizeMovement()
    {
        while (true)
        {
            movement.ChangeDirectionRandomly();
            yield return new WaitForSeconds(Random.Range(0.5f,3f));
        }
    }

    public void ChangeDirectionAfterTouchingWall(Direction direction)
    {
        StartCoroutine(movement.SlowChangingDirection(direction));
    }

    public void Die()
    {
        EventManager.OnEnemyKilled.Invoke();
        Destroy(gameObject);
    }
}
