using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitShop : MonoBehaviour
{
    public void TryBuyBaitT1()
    {
        if (GameData.Instance.Money < 5)
        {
            Debug.Log("Could not buy bait: not enough money!");
            return;
        }
        
        GameData.Instance.Money -= 5;
        GameData.Instance.BaitT1Amount += 1;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
    
    public void TryBuyBaitT2()
    {
        if (GameData.Instance.Money < 15)
        {
            Debug.Log("Could not buy bait: not enough money!");
            return;
        }
        
        GameData.Instance.Money -= 15;
        GameData.Instance.BaitT2Amount += 1;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
    
    public void TryBuyBaitT3()
    {
        if (GameData.Instance.Money < 30)
        {
            Debug.Log("Could not buy bait: not enough money!");
            return;
        }
        
        GameData.Instance.Money -= 30;
        GameData.Instance.BaitT3Amount += 1;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
}
