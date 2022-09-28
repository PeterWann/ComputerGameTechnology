using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
    public Mesh[] meshes = new Mesh[8];
    public GameObject currentLimb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("bob");

        // ChooseLimb();

        ShootLimb();
    }

    #region Choose Limb To Shoot
    void ChooseLimb()
    {
        Debug.Log("Test");
        // Get Current Amount Of Limbs
        int amount = player.GetComponent<BodyAndLimbs>().limbAmount;

        // Setup Mesh
        MeshFilter limbMesh;

        limbMesh = currentLimb.GetComponent<MeshFilter>();

        // Change Mesh According To Amount Left
        limbMesh.sharedMesh = meshes[amount];
    }
    #endregion

    #region Shoot Limb
    void ShootLimb()
    {
        rb.velocity = transform.right * speed;
    }
    #endregion

    private void OnCollisionEnter(Collision hitInfo)
    {
        // Logic for hitting enemies
    }
}
