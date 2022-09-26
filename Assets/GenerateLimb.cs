using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLimb : MonoBehaviour
{
    public float limbSpeed = 10f;

    public Rigidbody rb;
    public GameObject startingLimb;
    public Mesh[] limbMeshes = new Mesh[8];
    private GameObject player;
    private int limbAmount;

    private void Start()
    {
        player = GameObject.Find("Bob");

        limbAmount = player.GetComponent<BodyParts>().AmountLimbParts();

        ChooseLimb();

        ShootLimb();
    }

    void ChooseLimb()
    {
        MeshFilter limbMesh;

        limbMesh = startingLimb.GetComponent<MeshFilter>();

        limbMesh.sharedMesh = limbMeshes[limbAmount];
    }

    void ShootLimb()
    {
        rb.velocity = transform.right * limbSpeed;
    }
}
