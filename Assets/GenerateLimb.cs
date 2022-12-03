using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLimb : MonoBehaviour
{
    public float limbSpeed = 10f;
    public float limbMass = 20f;

    public Rigidbody rb;
    public GameObject startingLimb;
    public MeshCollider meshCollider;
    public Mesh[] limbMeshes = new Mesh[8];
    private int limbAmount;

    private void Start()
    {
        limbAmount = BodyParts.Instance.AmountLimbParts();

        ChooseLimb();

        ShootLimb();
    }

    void ChooseLimb()
    {
        MeshFilter limbMesh;

        limbMesh = startingLimb.GetComponent<MeshFilter>();

        limbMesh.sharedMesh = limbMeshes[limbAmount];
        meshCollider.sharedMesh = limbMeshes[limbAmount];
    }

    void ShootLimb()
    {
        rb.mass = limbMass;
        rb.velocity = transform.right * limbSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayOnce("LimbHit");
    }


}
