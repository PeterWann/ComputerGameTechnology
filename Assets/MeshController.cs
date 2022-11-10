using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public GameObject startingMesh;
    public Mesh[] bodyMeshes = new Mesh[8];
    private Animator animator;
    public Material[] playerHit = new Material[1];
    public Material[] playerNotHit = new Material[1];
    private SkinnedMeshRenderer bodyMesh;

    private void Start()
    {
        animator = GameObject.Find("Bob").GetComponent<Animator>();
    }

    public void ChangeMesh(int bodyPart)
    {
        bodyMesh = startingMesh.GetComponent<SkinnedMeshRenderer>();

        bodyMesh.materials = playerNotHit;

        bodyMesh.sharedMesh = bodyMeshes[bodyPart];


        ChangeAnimation(bodyPart);
    }

    public void PlayerHit()
    {
        bodyMesh = startingMesh.GetComponent<SkinnedMeshRenderer>();

        bodyMesh.materials = playerHit;
    }

    public void ChangeAnimation(int bodyPart)
    {
        if (bodyPart >= 4)
        {
            animator.SetBool("isOneLeg", false);
        } else if(bodyPart < 4 && bodyPart >= 2)
        {
            animator.SetBool("isOneLeg", true);
            animator.SetBool("isZeroLeg", false);
        } else
        {
            animator.SetBool("isOneLeg", false);
            animator.SetBool("isZeroLeg", true);
        }
    }
}
