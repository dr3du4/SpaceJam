using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FishSell : MonoBehaviour
{
    private GameObject hand;
    public int FishValue;
    private FishBase fb;
    public void SellFish()
    {

        GameData.Instance.Money += FishValue;
        GameData.Instance.OnGameDataChanged.Invoke();
        
    }


    public void Start()
    {
        hand=GameObject.FindGameObjectWithTag("hand");
    }

    private void Update()
    {
        if (transform.position.y > hand.transform.position.y)
        {
            SellFish();
            Destroy(this.gameObject);
            GameObject bite = GameObject.FindWithTag("Bite");
            bite.GetComponentInChildren<Attractor>().changeAttraction();
        }
            
    }
}