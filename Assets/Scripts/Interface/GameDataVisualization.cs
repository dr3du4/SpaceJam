using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDataVisualization : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text quotaText;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text timeRemaining;
    [SerializeField] private Canvas endScreen;

    private void Start()
    {
        GameData.Instance.OnGameDataChanged.AddListener(UpdateUI);
        UpdateUI();
    }

    private void OnDestroy()
    {
        GameData.Instance.OnGameDataChanged.RemoveListener(UpdateUI);
    }

    private void FixedUpdate()
    {
        var seconds = Mathf.RoundToInt(GameData.Instance.StartTime - Time.time) + GameData.Instance.TimeLimit;
        timeRemaining.text = $"{seconds / 60:D2}:{seconds % 60:D2}";

        if (seconds <= 0)
        {

            Debug.Log("Time end!");
            if(GameData.Instance.Quota >= GameData.Instance.Money)
            {
                GameData.Instance.OnTimeEnd?.Invoke();
            }
            else
            {
                GameData.Instance.Money = GameData.Instance.Money - GameData.Instance.Quota;
                GameData.Instance.Quota = GameData.Instance.Quota * 2;
                GameData.Instance.StartTime = Time.time;
                UpdateUI();
            }

        }
    }

    private void UpdateUI()
    {
        moneyText.text = $"{GameData.Instance.Money}$";
        quotaText.text = $"Quota: {GameData.Instance.Quota}$";
        ammoText.text = $"Ammo: {GameData.Instance.Ammo}";
    }

}
