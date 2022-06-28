using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAnimations
{
    [HideInInspector] public Vector3 defaultScale;

    public IEnumerator Spawn(Transform transform)
    {
        for (float t = 0; t <= 1f; t += Time.deltaTime * 3)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, defaultScale, t);
            yield return null;
        }
        transform.localScale = defaultScale;
    }

    public IEnumerator Hit(Transform transform)
    {
        for (float t = 0; t <= 1f; t += Time.deltaTime * 8)
        {
            transform.localScale = Vector3.Lerp(defaultScale, defaultScale * 0.6f, t);
            yield return null;
        }
        for (float t = 0; t <= 1f; t += Time.deltaTime * 8)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, t);
            yield return null;
        }
        transform.localScale = defaultScale;
    }
}