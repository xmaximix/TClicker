using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    public void SetRotationSpeed(Vector3 speed)
    {
        rotationSpeed = speed;
    }

    public Vector3 GetRotationSpeed()
    {
        return rotationSpeed;
    }
}
