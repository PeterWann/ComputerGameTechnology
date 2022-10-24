using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject pincode;
    [SerializeField]
    private BoxCollider doorCollider;

    private void Awake()
    {
        doorCollider.enabled = false;
    }

    public void OpenDoor()
    {
        doorCollider.enabled = true;
        pincode.GetComponent<Pincode>().HasInteracted();
        anim.SetBool("DoorOpen", true);
    }
}
