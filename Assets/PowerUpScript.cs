using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private BodyParts bodyParts;
    [SerializeField]
    private float powerupTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        bodyParts = BodyParts.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(StartPowerUp(other));
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator StartPowerUp(Collider other)
    {
        bodyParts.powerUpActivated = true;

        yield return new WaitForSeconds(powerupTime);

        bodyParts.powerUpActivated = false;

        Destroy(gameObject);
    }

}
