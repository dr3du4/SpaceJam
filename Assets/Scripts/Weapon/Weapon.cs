using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<float> shootTimings;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private FishBase fish;

    protected readonly Timer timer = new();
    protected int shootIndex = 0;
    protected Transform playerTransform;
    protected bool catched = false;

    protected virtual void Awake()
    {
        var playerScript = FindFirstObjectByType<Player>();
        playerTransform = playerScript.BulletTarget;
        if (playerTransform == null)
        {
            Debug.LogError("There is no object with Player tag on!");
            return;
        }
        
        if (shootTimings.Count <= 0)
        {
            Debug.LogError("No shoot timings set for weapon!");
            return;
        }
        
        fish.OnFishCatched.AddListener(FishCatched);
        
        timer.Start(shootTimings[0]);
    }

    protected void OnDestroy()
    {
        fish.OnFishCatched.RemoveListener(FishCatched);
    }

    protected virtual void FixedUpdate()
    {
        if (!catched)
            return;
        
        TryShoot();
    }

    public virtual void TryShoot()
    {
        if (!timer.IsFinished())
            return;
        
        Shoot();
        shootIndex++;
        if (shootIndex >= shootTimings.Count)
            shootIndex = 0;
        timer.Start(shootTimings[shootIndex]);
    }

    protected virtual void Shoot()
    {
        var direction = (new Vector2(playerTransform.position.x, playerTransform.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    
    protected virtual void FishCatched()
    {
        catched = true;
    }
}
