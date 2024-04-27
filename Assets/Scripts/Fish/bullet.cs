using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Update = UnityEngine.PlayerLoop.Update;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter()
    {
            Destroy(gameObject);
    }
}
