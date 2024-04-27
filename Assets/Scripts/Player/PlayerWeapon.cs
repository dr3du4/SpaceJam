using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private enum State
    {
        Grabbed,
        Released
    }
    
    [SerializeField] private GameObject weaponVisual;
    [SerializeField] private State state = State.Released;
    [SerializeField] private Kneeling kneeling;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Transform shootingTransform;
    
    public bool CanShoot => state == State.Grabbed;

    private void Awake()
    {
        ApplyState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            state = state == State.Grabbed ? State.Released : State.Grabbed;
            ApplyState();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot)
        {
            if (GameData.Instance.Ammo <= 0)
                return;

            var cam = FindAnyObjectByType<Camera>(FindObjectsInactive.Exclude);
            var mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            var direction = (mouseWorldPos - shootingTransform.position).normalized;
            var bullet = Instantiate(bulletPrefab, shootingTransform.position, Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            GameData.Instance.Ammo--;
            GameData.Instance.OnGameDataChanged.Invoke();
        }
    }

    private void ApplyState()
    {
        switch (state)
        {
            case State.Grabbed:
                weaponVisual.SetActive(true);
                kneeling.canSpin = false;
                break;
            case State.Released:
                weaponVisual.SetActive(false);
                kneeling.canSpin = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
