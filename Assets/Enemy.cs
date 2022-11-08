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
    [SerializeField]
    private float walkSpeed = 4f;
    [SerializeField]
    private float runSpeed = 8f;
    [SerializeField]
    private float waitForHit = 1f;
    private float calcDistance;
    private bool isHit = false;
    private bool isDead = false;
    private Vector3 moveLeft = new Vector3(-1f, 0, 0);

    private void FixedUpdate()
    {
        calcDistance = Vector3.Distance(this.transform.position, player.transform.position);
        if (!isHit && !isDead) {
            if (calcDistance >= distanceToRun) {
            Walking();
            } else if (calcDistance >= distanceToHit) {
            Running();
            } else {
            Boxing();
            }
        }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Limb(Clone)")
        {
            collision.collider.name = "Limb(NoNeed)";
            StartCoroutine(EnemyHit());
            // Only first hit, ignore rest.
            Physics.IgnoreCollision(collision.collider, enemyCollider);
        }
    }

    IEnumerator EnemyHit() {
        hitpoints -= 20;
        anim.SetTrigger("IsHit");

        isHit = true;

        if (hitpoints <= 0) {
            EnemyDeath();

            isDead = true;
        }

        yield return new WaitForSeconds(waitForHit);

        isHit = false;
    }

    void EnemyDeath()
    {
        Destroy(rb);
        Destroy(enemyCollider);
        anim.SetBool("IsDead", true);
    }

    void Walking() {
        anim.SetBool("IsRunning", false);
        rb.MovePosition(transform.position + moveLeft * Time.deltaTime * walkSpeed);
    }

    void Running() {
        anim.SetBool("IsRunning", true);
        rb.MovePosition(transform.position + moveLeft * Time.deltaTime * runSpeed);
    }

    void Boxing() {
        anim.SetBool("IsRunning", false);
        anim.SetTrigger("IsBoxing");
    }

}
