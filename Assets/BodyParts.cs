using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    private int bodyParts = 8;
    private int limbParts = 8;

    public void DecreaseParts()
    {
        if (bodyParts >= 1)
        {
            bodyParts -= 1;
        }
    }

    public void DecreaseLimbs()
    {
        if (limbParts >= 1)
        {
            limbParts -= 1;
        }
    }

    public void IncreaseLimbsAndParts()
    {
        bodyParts += 1;
        limbParts += 1;
    }

    public int AmountBodyParts()
    {
        return bodyParts;
    }

    public int AmountLimbParts()
    {
        return limbParts;
    }
}
