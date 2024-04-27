using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
  public Button button1;
  public Button button2;
  public Button button3;

  public FollowAndLaunch fl;
  public bait_Script bs;
  public void TryBuyUpgrade1()
  {
    if (GameData.Instance.Money < 5)
    {
      Debug.Log("Could not buy bait: not enough money!");
      return;
    }

    GameData.Instance.Money -= 5;
    fl.launchForce += 10;
    GameData.Instance.OnGameDataChanged.Invoke();
    button1.interactable = false;

  }

  public void  TryBuyUpgrade2()
  {
    if (GameData.Instance.Money < 15)
    {
      Debug.Log("Could not buy bait: not enough money!");
      return;
    }
        
    GameData.Instance.Money -= 15;
    bs.movementSpeed += 2;
    GameData.Instance.OnGameDataChanged.Invoke();
    button2.interactable = false;
  }
    
  public void  TryBuyUpgrade3()
  {
    if (GameData.Instance.Money < 30)
    {
      Debug.Log("Could not buy bait: not enough money!");
      return;
    }
        
    GameData.Instance.Money -= 30;
    bs.drowing+=2;
    GameData.Instance.OnGameDataChanged.Invoke();
    button3.interactable = false;
  }
}
