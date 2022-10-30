using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private BoxCollider enemyCollider;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int hitpoints = 40;
    [SerializeField]
    private float distanceToRun = 22f;
    [SerializeField]
    private float distanceToHit = 3.3f;
    private float calcDistance;

    private void Update()
    {
        calcDistance = Vector3.Distance(this.transform.position, player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Limb(Clone)")
        {
            EnemyHit();
            // Only first hit, ignore rest.
            Physics.IgnoreCollision(collision.collider, enemyCollider);
        }
    }

    void EnemyHit()
    {
        hitpoints -= 20;
        anim.SetTrigger("IsHit");

        if (hitpoints <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Destroy(rb);
        Destroy(enemyCollider);
        anim.SetBool("IsDead", true);
    }

}
