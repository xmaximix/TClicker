using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float playTime;

    public static void CountTime()
    {
        playTime += Time.deltaTime;
    }

    public static float GetPlayTime()
    {
        return playTime;
    }

    public static void ResetTimer()
    {
        playTime = 0;
    }
}
