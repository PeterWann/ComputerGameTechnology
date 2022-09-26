using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAndLimbs : MonoBehaviour
{
    public int limbAmount = 8;
    public int bodyAmount = 9;

    public void DecreaseLimb()
    {
        if (limbAmount >= 1)
        {
            limbAmount -= 1;
        }
    }
}
