using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private TMP_Text baitT1AmountText;
    [SerializeField] private TMP_Text baitT2AmountText;
    [SerializeField] private TMP_Text baitT3AmountText;
    [SerializeField] private Attractor attractor;

    private void Awake()
    {
        GameData.Instance.OnGameDataChanged.AddListener(RefreshBaitAmounts);
    }

    private void OnDestroy()
    {
        GameData.Instance.OnGameDataChanged.RemoveListener(RefreshBaitAmounts);
    }

    private void RefreshBaitAmounts()
    {
        baitT1AmountText.text = $"T1 Bait ({GameData.Instance.BaitT1Amount.ToString()})";
        baitT2AmountText.text = $"T2 Bait ({GameData.Instance.BaitT2Amount.ToString()})";
        baitT3AmountText.text = $"T3 Bait ({GameData.Instance.BaitT3Amount.ToString()})";
    }

    public void TryEquipT1Bait()
    {
        if (GameData.Instance.BaitT1Amount <= 0)
        {
            Debug.Log("There is no T1 bait to equip.");
            return;
        }

        // TODO: Equip T1 bait
        attractor.changeBaitLevel(1);
        GameData.Instance.BaitT1Amount--;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
    
    public void TryEquipT2Bait()
    {
        if (GameData.Instance.BaitT2Amount <= 0)
        {
            Debug.Log("There is no T2 bait to equip.");
            return;
        }

        // TODO: Equip T2 bait
        attractor.changeBaitLevel(2);
        GameData.Instance.BaitT2Amount--;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
    
    public void TryEquipT3Bait()
    {
        if (GameData.Instance.BaitT3Amount <= 0)
        {
            Debug.Log("There is no T3 bait to equip.");
            return;
        }

        // TODO: Equip T3 bait
        attractor.changeBaitLevel(3);
        GameData.Instance.BaitT3Amount--;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
}
