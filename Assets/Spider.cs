using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject splat;
    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(splat, splat.transform.position, splat.transform.rotation);
        Object.Destroy(spider);
    }
}
