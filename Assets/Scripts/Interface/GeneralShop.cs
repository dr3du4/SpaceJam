using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralShop : MonoBehaviour
{
    public void TryBuyAmmo()
    {
        if (GameData.Instance.Money < 10)
        {
            Debug.Log("Could not buy ammo: not enough money!");
            return;
        }
        
        GameData.Instance.Money -= 10;
        GameData.Instance.Ammo += 10;
        GameData.Instance.OnGameDataChanged.Invoke();
    }
}
