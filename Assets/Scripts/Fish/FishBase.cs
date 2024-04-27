using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public struct AttractionParams
{
    public float attractionChance;
}

public enum State
{
    roaming,
    chasing
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
    
    public abstract void TryAttract(AttractionParams @params, Transform target);

    protected BoxCollider2D fishCollider;
    protected Vector3 startingPosition;
    protected Vector2 randomTimeOffset;
    protected State currentState;
    protected Transform target;

    protected virtual void Awake()
    {
        fishCollider = GetComponent<BoxCollider2D>();
        startingPosition = transform.position;
        randomTimeOffset = new Vector2(Random.value, Random.value);
        currentState = State.roaming;
    }

    protected virtual void Update()
    {
        switch (currentState)
        {
            case State.roaming:
                transform.position = startingPosition + new Vector3(fishTimePositionX.Evaluate(Time.time + randomTimeOffset.x), fishTimePositionY.Evaluate(Time.time + randomTimeOffset.y), 0);
                break;
            case State.chasing:
                transform.position = Vector3.MoveTowards(transform.position, target.position, 0.2f);
                break;
        }
        
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
