using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayLoop("ClockTickTock");
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject clock = GameObject.Find("Clock");

        AudioManager.Instance.StopPlay("ClockTickTock");
        AudioManager.Instance.PlayOnce("ClockHit");

        clock.AddComponent<Rigidbody>();

        clock.GetComponent<Rigidbody>().mass = 10;
        clock.GetComponent<Rigidbody>().drag = 0;
        clock.GetComponent<Rigidbody>().AddForce(Physics.gravity * 10);
        clock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
