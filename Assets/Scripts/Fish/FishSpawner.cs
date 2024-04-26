using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class FishSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int FishAmount = 10;

    [SerializeField] private List<GameObject> FishPrefabs;
    
    [Header("Events")]
    public UnityEvent OnFishSpawned;

    public Bounds Bounds => objCollider.bounds;
    
    private BoxCollider2D objCollider;

    private void Awake()
    {
        objCollider = GetComponent<BoxCollider2D>();
        
        SpawnFish();
    }

    public void SpawnFish()
    {
        var startingPoint = Bounds.min + Bounds.size.y * Vector3.up;
        
        for (var i = 0; i < FishAmount; i++)
        {
            var x = Random.value;
            var y = Random.value;
            
            var position = Bounds.min + new Vector3(x * Bounds.size.x, y * Bounds.size.y, 0);

            foreach (var prefab in FishPrefabs.OrderBy(obj => Guid.NewGuid()))
            {
                if (!prefab.GetComponent<FishBase>().CanSpawn(new FishSpawnParams
                    {
                        DistanceX = (position.x - startingPoint.x) / Bounds.size.x,
                        DistanceY = (startingPoint.y - position.y) / Bounds.size.y
                    }))
                    continue;
                
                var fish = Instantiate(prefab, position, Quaternion.identity);
                break;
            }
        }
        
        OnFishSpawned?.Invoke();
    }
}
