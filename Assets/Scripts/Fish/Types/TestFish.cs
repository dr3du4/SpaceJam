using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFish : FishBase
{
    public override bool TryAttract(AttractionParams @params)
    {
        if (Random.value < @params.attractionChance && @params.baitLevel >= fishLevel)
        {
            currentState = State.chasing;
            this.target = @params.origin;
            return true;
        }
        return false;
    }


}
