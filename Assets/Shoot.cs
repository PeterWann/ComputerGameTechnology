using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject limbPrefab;
    private GameObject player;
    private GameObject playerMesh;

    private float shootAngle;

    void Awake()
    {
        player = GameObject.Find("Bob");
        playerMesh = GameObject.Find("BobMesh");
    }

    void Update()
    {
            ShootAngle();

            if (Input.GetButtonDown("Fire1"))
            {
                if (!player.GetComponent<PlayerController>().freezePlayer)
                {
                    ShootLimb();

                    DecreaseMesh();
                }
            }
    }

    void ShootAngle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - player.transform.position;

        shootAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    void ShootLimb()
    {
        int limbsLeft = player.GetComponent<BodyParts>().AmountLimbParts();
 
        if (limbsLeft > 0 )
        {
            firePoint.rotation = Quaternion.Euler(firePoint.rotation.x, firePoint.rotation.y, shootAngle);
            limbPrefab.transform.localScale = player.transform.parent.transform.localScale;
            GameObject limb = Instantiate(limbPrefab, firePoint.position, firePoint.rotation);
            Physics.IgnoreCollision(limb.GetComponent<Collider>(), player.GetComponent<CapsuleCollider>());

            player.GetComponent<BodyParts>().DecreaseLimbs();
            
        }
    }

    void DecreaseMesh()
    {
        if (player.GetComponent<BodyParts>().AmountBodyParts() > 0)
        {
            
            player.GetComponent<BodyParts>().DecreaseParts();
          

            playerMesh.GetComponent<MeshController>().ChangeMesh(player.GetComponent<BodyParts>().AmountBodyParts());
        }
    }

    void IncreaseMesh()
    {
        int partsLeft = player.GetComponent<BodyParts>().AmountBodyParts();

        playerMesh.GetComponent<MeshController>().ChangeMesh(partsLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Limb(Clone)" || other.name == "Limb(NoNeed)") {
            Object.Destroy(other.gameObject);
            player.GetComponent<BodyParts>().IncreaseLimbsAndParts();

            IncreaseMesh();
        }
    }

}
