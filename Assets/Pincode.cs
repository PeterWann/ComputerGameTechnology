
using UnityEngine;

public class Pincode : Interactable
{
    [SerializeField]
    private GameObject codePanelPrefab;
    [SerializeField]
    private GameObject playerObject;
    
    private GameObject codePanelInteractable;

    private bool isPanelOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isPanelOpen)
            {
                Interact();
            } else
            {
                CloseInteraction();
            }
        }
    }

    public override void Interact()
    {
        playerObject.GetComponent<PlayerController>().freezePlayer = true;
        Vector3 codePanelPosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width / 2, Screen.height / 2, 10));

        codePanelInteractable = Instantiate(codePanelPrefab, codePanelPosition, Quaternion.identity);
        codePanelInteractable.SetActive(true);

        isPanelOpen = true;
    }

    public void CloseInteraction()
    {
        playerObject.GetComponent<PlayerController>().freezePlayer = false;
        Destroy(codePanelInteractable);
        
        isPanelOpen = false;
    }
}
