using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FishSpawnSettings
{
    [Range(0f, 1f)] public float MinDistanceX;
    [Range(0f, 1f)] public float MinDistanceY;
    [Range(0f, 1f)] public float MaxDistanceX = 1f;
    [Range(0f, 1f)] public float MaxDistanceY = 1f;
}
