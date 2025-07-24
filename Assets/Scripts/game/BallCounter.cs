using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter
{
    public static BallCounter counter = new BallCounter();

    int balls;

    public Action<int> counterChange;

    public int numBall
    {
        get { return balls; }
        set
        {
            balls = value;
            counterChange?.Invoke(numBall);
        }
    }

    public void AddBall()
    {
        balls++;
        counterChange?.Invoke(numBall);
    }

    public void RemoveBall()
    {
        balls--;
        counterChange?.Invoke(numBall);
    }
}
