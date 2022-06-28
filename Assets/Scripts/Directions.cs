using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North,
    East,
    South,
    West
}

public static class Directions
{
    private static Quaternion[] rotations =
    {
        Quaternion.Euler(0f,0f,0f),
        Quaternion.Euler(0f,90f,0f),
        Quaternion.Euler(0f,180f,0f),
        Quaternion.Euler(0f,270f,0f)
    };

    public static Quaternion GetDirection(Direction direction)
    {
        return rotations[((int)direction)];
    }
}
