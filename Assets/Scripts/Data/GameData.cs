using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Stats")]
    [field: SerializeField] public int Money { get; set; } = 50;
    [field: SerializeField] public int Quota { get; set; } = 100;
    [field: SerializeField] public int Ammo { get; set; } = 10;
    [field: SerializeField] public List<Bait> Baits { get; private set; } = new();
    [field: SerializeField] public float StartTime { get; set; } = 0;
    [field: SerializeField] public int TimeLimit { get; private set; } = 60 * 3;

    [Header("Events")]
    public UnityEvent OnGameDataChanged;

    public UnityEvent OnTimeEnd;
}
