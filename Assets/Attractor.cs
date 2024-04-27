using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    AttractionParams AttractionParams;
    [SerializeField] private SpriteRenderer baitRenderer;
    [SerializeField] private List<Sprite> baitSprites;
    protected List<FishBase> attractedFish = new List<FishBase>();
    protected bool isCaught;

    private void Start()
    {
        isCaught = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCaught) return;

        if(collision.CompareTag("Fish"))
        {
            // je�li uda�o si� zatractowa� rybe to dodaj do listy
            if (collision.GetComponent<FishBase>().TryAttract(AttractionParams))
            {
                attractedFish.Add(collision.GetComponent<FishBase>());
            }
        }
    }

    public void ClearAttraction(FishBase caughtFish)
    {
        isCaught = true;
        foreach(FishBase fish in attractedFish)
        {
            if(!ReferenceEquals(fish, caughtFish))
            {
                fish.currentState = State.roaming;
            }
        }
    }

    public void changeAttraction()
    {
        isCaught = false;
        AttractionParams.baitLevel = 0;
        
        baitRenderer.sprite = baitSprites[0];
    }

    public void changeBaitLevel(int level)
    {
        AttractionParams.baitLevel = level;
        
        baitRenderer.sprite = baitSprites[level];
    }
}
