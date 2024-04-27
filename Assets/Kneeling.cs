using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Kneeling : MonoBehaviour
{
    public GameObject shield;
    public GameObject rod;
    public GameObject followCamera;
    public GameObject shieldCamera;

    public bool canSpin
    {
        get => spinDisableCount == 0;
        set
        {
            if (!value)
                spinDisableCount++;
            else
            {
                spinDisableCount--;
                if (spinDisableCount < 0)
                    spinDisableCount = 0;
            }
        }
    }

    [SerializeField] private int spinDisableCount = 0;
    
    private void Start()
    {
        shield.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            canSpin = false;
            shield.SetActive(true);
            rod.SetActive(false);
            shieldCamera.SetActive(true);
            followCamera.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canSpin = true;
            shield.SetActive(false);
            rod.SetActive(true);
            shieldCamera.SetActive(false);
            followCamera.SetActive(true);
            
        }

    }
}
