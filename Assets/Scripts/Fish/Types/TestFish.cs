using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFish : FishBase
{
    public override void TryAttract(AttractionParams @params)
    {
        if (Random.value < @params.attractionChance)
        {
            Debug.Log("Fish attracted!");
        }
    }
}
