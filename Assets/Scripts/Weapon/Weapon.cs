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
        playerTransform = GameObject.FindWithTag("Player").transform;
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
        var direction = (playerTransform.position - transform.position).normalized;
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(direction));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    
    protected virtual void FishCatched()
    {
        catched = true;
    }
}
