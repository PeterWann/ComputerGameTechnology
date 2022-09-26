using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLimb : MonoBehaviour
{
    public Transform firePoint;
    public GameObject limbPrefab;
    public GameObject currentSkin;
    private GameObject player;
    public Mesh newMesh;

    private float shootAngle;

    void Start()
    {
        player = GameObject.Find("bob");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference.Normalize();

        shootAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        
    }
    
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    #region Shooting Logic
    void Shoot()
    {
        SkinnedMeshRenderer playerMesh;

        playerMesh = currentSkin.GetComponent<SkinnedMeshRenderer>();

        playerMesh.sharedMesh = newMesh;

        Debug.Log(newMesh);

        firePoint.rotation = Quaternion.Euler(firePoint.rotation.x, firePoint.rotation.y, shootAngle);
        Instantiate(limbPrefab, firePoint.position, firePoint.rotation);
    }
    #endregion
}
