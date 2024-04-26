using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FishSpawnParams
{
    [Range(0f, 1f)] public float DistanceX;
    [Range(0f, 1f)] public float DistanceY;
}
