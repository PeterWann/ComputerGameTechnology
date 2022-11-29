using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public GameObject startingMesh;
    public Mesh[] bodyMeshes = new Mesh[8];
    private Animator animator;

    private void Start()
    {
        animator = GameObject.Find("Bob").GetComponent<Animator>();
    }

    public void ChangeMesh(int bodyPart)
    {
        SkinnedMeshRenderer bodyMesh;

        bodyMesh = startingMesh.GetComponent<SkinnedMeshRenderer>();

        bodyMesh.sharedMesh = bodyMeshes[bodyPart];

        ChangeAnimation(bodyPart);
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
