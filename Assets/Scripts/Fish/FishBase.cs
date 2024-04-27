using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public struct AttractionParams
{
    public Transform origin;
    public float attractionChance;
    public int baitLevel;
}

public enum State
{
    roaming,
    chasing,
    bite
}

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class FishBase : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AnimationCurve fishTimePositionX;
    [SerializeField] private AnimationCurve fishTimePositionY;
    [SerializeField] private Transform attachPoint;
    public float chaseSpeed;
    public FishSpawnSettings SpawnSettings;
    public int fishLevel;

    [Header("Events")]
    public UnityEvent OnFishCatched;
    
    public abstract bool TryAttract(AttractionParams @params);

    protected BoxCollider2D fishCollider;
    protected Vector3 startingPosition;
    protected Vector2 randomTimeOffset;
    public State currentState;
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
                transform.position = Vector3.MoveTowards(transform.position, target.position - attachPoint.localPosition, Time.deltaTime * chaseSpeed);
                break;
            case State.bite:
                transform.position = target.position - attachPoint.localPosition;
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bite") && currentState == State.chasing)
        {
            other.GetComponentInChildren<Attractor>().ClearAttraction(this);
            Catch();
            OnFishCatched?.Invoke();
        }
    }

    public virtual void Catch()
    {
        currentState = State.bite;
        Debug.Log("Catch invoked!");
    }

    public virtual bool CanSpawn(FishSpawnParams @params)
    {
        return @params.DistanceX >= SpawnSettings.MinDistanceX && @params.DistanceX <= SpawnSettings.MaxDistanceX &&
               @params.DistanceY >= SpawnSettings.MinDistanceY && @params.DistanceY <= SpawnSettings.MaxDistanceY;
    }
}
