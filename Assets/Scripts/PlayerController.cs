using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public GameObject interactIcon;

    private Rigidbody rb;
    private Animator animator;
    private AudioManager audioManager;

    private Vector3 m_Input;
    private bool isFacingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        // interactIcon.SetActive(false);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioManager = AudioManager.Instance;
    }

    private void FixedUpdate()
    {   
        GetInputs();

        CheckDirection();

        Running();
    }

    #region Check Direction / Flip Player

    void CheckDirection()
    {
        if (m_Input.x < 0 && !isFacingLeft)
        {
            Flip(-90);
        }
        else if (m_Input.x > 0 && isFacingLeft)
        {
            Flip(90);
        }
    }

    void Flip(int deg)
    {
        isFacingLeft = !isFacingLeft;

        transform.rotation = Quaternion.Euler(0, deg, 0);
    }

    #endregion

    #region Get Inputs
    void GetInputs()
    {
        m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    #endregion

    #region Running

    void Running()
    {
        if (m_Input.x != 0)
        {
            rb.MovePosition(transform.position + m_Input * Time.deltaTime * runSpeed);
            animator.SetBool("isRunning", true);
            audioManager.Play("PlayerRun");
        }
        else
        {
            animator.SetBool("isRunning", false);
            audioManager.StopPlay("PlayerRun");
        }
    }

    #endregion
}
