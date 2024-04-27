using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    public Transform BulletTarget;
        

    private int maxHealth;

    private void Start()
    {
        GameData.Instance.OnGameDataChanged.AddListener(UpdateHealth);
        maxHealth = GameData.Instance.Health;
    }
    
    private void OnDestroy()
    {
        GameData.Instance.OnGameDataChanged.RemoveListener(UpdateHealth);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            GameData.Instance.Health -= 1;
            GameData.Instance.OnGameDataChanged.Invoke();
        }
    }

    private void UpdateHealth()
    {
        healthText.text = $"{GameData.Instance.Health * 100 / maxHealth}%";
    }
}
