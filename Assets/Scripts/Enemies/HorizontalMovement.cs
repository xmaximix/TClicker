using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HorizontalMovement 
{
    [SerializeField] public float speed;
    private float defaultSpeed;
    private bool movementRandomizable = true;

    private Direction currentDirection;

    private Transform transform;
    private Transform arena;

    public void SetTransform(Transform component)
    {
        transform = component;
    }

    public void SetArena(Transform arenaTransform)
    {
        arena = arenaTransform;
    }

    public void Move()
    {
       transform.Translate(speed * Time.deltaTime * Vector3.forward) ;
    }

    private void ApplyRotation(Direction direction)
    {
        var angle = Directions.GetDirection(direction);
        transform.eulerAngles = angle.eulerAngles + arena.transform.eulerAngles;
    }

    public void ChangeDirection(Direction newDirection)
    {
        currentDirection = newDirection;
        ApplyRotation(currentDirection);
    }

    public void ChangeDirectionRandomly()
    {
        if (movementRandomizable)
        {
            var randomDirection = (Direction)Random.Range(0, 4);
            while (currentDirection == randomDirection)
            {
                randomDirection = (Direction)Random.Range(0, 4);
            }
            currentDirection = randomDirection;

            ApplyRotation(currentDirection);
        }
    }

    public IEnumerator SlowChangingDirection(Direction direction)
    {
        currentDirection = direction;
        ApplyRotation(direction);

        movementRandomizable = false;
        defaultSpeed = speed;
        for (float t = 0; t <= 1; t += Time.deltaTime * 2)
        {
            speed = Mathf.Lerp(defaultSpeed / 2, defaultSpeed, t);
            yield return null;
        }
        speed = defaultSpeed;
        movementRandomizable = true;
    }
}
