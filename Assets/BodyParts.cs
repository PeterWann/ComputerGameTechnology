using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public static BodyParts Instance { get; private set; }

    private int bodyParts = 8;
    private int limbParts = 8;

    public bool powerUpActivated;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }

        powerUpActivated = false;
    }

    public void DecreaseParts()
    {
        if (!powerUpActivated)
        {
            if (bodyParts >= 1)
            {
                bodyParts -= 1;
            }
        }
    }

    public void DecreaseLimbs()
    {
        if (!powerUpActivated)
        {
            if (limbParts >= 1)
            {
                limbParts -= 1;
            }
        }
       
    }

    public void IncreaseLimbsAndParts()
    {
        if (!powerUpActivated)
        {
            if (bodyParts < 8 && limbParts < 8)
            {
                bodyParts += 1;
                limbParts += 1;
            }
        }
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
