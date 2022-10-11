using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject interactableIconPrefab;

    [SerializeField]
    private GameObject player;

    private GameObject interactableIcon;
    public bool hasInteracted = false;
    public bool canInteract = false;

    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            canInteract = true;

            Vector3 textPosition = new Vector3(
                this.transform.position.x,
                this.transform.position.y - 0.5f,
                -5);
            interactableIcon = Instantiate(interactableIconPrefab, textPosition, Quaternion.identity);
            interactableIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            Destroy(interactableIcon);
        }
    }

    public void HasInteracted()
    {
        hasInteracted = true;
        Destroy(interactableIcon);
    }
}
