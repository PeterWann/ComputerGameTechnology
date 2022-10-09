
using UnityEngine;

public class Pincode : Interactable
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public override void Interact()
    {
        Debug.Log("Open Codepanel");
    }
}
