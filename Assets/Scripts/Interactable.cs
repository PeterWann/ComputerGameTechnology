using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject interactableIconPrefab;

    [SerializeField]
    private GameObject player;

    private GameObject interactableIcon;

    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 textPosition = new Vector3(
                player.transform.position.x + 0.5f,
                player.transform.position.y + 2,
                -5);
            interactableIcon = Instantiate(interactableIconPrefab, textPosition, Quaternion.identity);
            interactableIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(interactableIcon);
        }
    }
}
