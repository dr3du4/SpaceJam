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
