using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float start;
    private float duration;

    public void Start(float _duration)
    {
        duration = _duration;
        start = Time.time;
    }
    
    public bool IsFinished()
    {
        return Time.time - start >= duration;
    }
}
