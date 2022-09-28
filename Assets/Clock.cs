using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject clock = GameObject.Find("Clock");
        clock.AddComponent<Rigidbody>();

        clock.GetComponent<Rigidbody>().mass = 2;
        clock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
