using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFish : FishBase
{
    public override void TryAttract(AttractionParams @params, Transform target)
    {
        if (Random.value < @params.attractionChance)
        {
            currentState = State.chasing;
            this.target = target;
            Debug.Log("Fish attracted!");
        }
    }
}
