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
    public AudioClip cashout;
    private FishBase fb;
    private bool sold=false;

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
            AudioSource.PlayClipAtPoint(cashout, transform.position);
            Destroy(this.gameObject);
            SellFish();
            GameObject bite = GameObject.FindWithTag("Bite");
            bite.GetComponentInChildren<Attractor>().changeAttraction();
        }
            
    }
  


IEnumerator FreezeGame()
{
    
    Time.timeScale = 0;

    Debug.Log("Dsdasdsdad");
    yield return new WaitForSecondsRealtime(1f);
    
    
    Time.timeScale = 1;
}
}