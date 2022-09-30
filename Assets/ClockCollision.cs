using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Hitbox_Ground")
        {
            Object.Destroy(GameObject.Find("Clock").transform.GetChild(2).gameObject);
            AudioManager.Instance.PlayOnce("ClockHit");
        }
    }
}
