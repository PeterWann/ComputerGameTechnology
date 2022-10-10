using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject pincode;

    public void OpenDoor()
    {
        pincode.GetComponent<Pincode>().HasInteracted();
        anim.SetBool("DoorOpen", true);
    }
}
