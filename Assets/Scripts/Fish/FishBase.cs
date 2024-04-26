using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public struct AttractionParams
{
    public float attractionChance;
}

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class FishBase : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AnimationCurve fishTimePositionX;
    [SerializeField] private AnimationCurve fishTimePositionY;
    public FishSpawnSettings SpawnSettings;

    [Header("Events")]
    public UnityEvent OnFishCatched;
    
    public abstract void TryAttract(AttractionParams @params);

    protected BoxCollider2D fishCollider;
    protected Vector3 startingPosition;
    protected Vector2 randomTimeOffset;

    protected virtual void Awake()
    {
        fishCollider = GetComponent<BoxCollider2D>();
        startingPosition = transform.position;
        randomTimeOffset = new Vector2(Random.value, Random.value);
    }

    protected virtual void Update()
    {
        transform.position = startingPosition + new Vector3(fishTimePositionX.Evaluate(Time.time + randomTimeOffset.x), fishTimePositionY.Evaluate(Time.time + randomTimeOffset.y), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bite"))
        {
            Catch();
            OnFishCatched?.Invoke();
        }
    }

    public virtual void Catch()
    {
        // TODO: Catching logic
    }

    public virtual bool CanSpawn(FishSpawnParams @params)
    {
        return @params.DistanceX >= SpawnSettings.MinDistanceX && @params.DistanceX <= SpawnSettings.MaxDistanceX &&
               @params.DistanceY >= SpawnSettings.MinDistanceY && @params.DistanceY <= SpawnSettings.MaxDistanceY;
    }
}
