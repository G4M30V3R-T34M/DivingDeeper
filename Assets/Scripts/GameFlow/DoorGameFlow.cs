using UnityEngine;

public class DoorGameFlow : MonoBehaviour
{
    [SerializeField]
    Collider2D doorCollider;

    [SerializeField]
    GameObject doorCanvas;

    [SerializeField]
    GameObject interactableIndicator;

    public void HideChildren()
    {
        doorCollider.gameObject.SetActive(false);
        doorCanvas.gameObject.SetActive(false);
        interactableIndicator.gameObject.SetActive(false);
    }

    public void VisibleButInactive()
    {
        doorCollider.enabled = false;
        interactableIndicator.gameObject.SetActive(false);
    }

    public void DoorActive()
    {
        doorCollider.enabled = true;
        doorCollider.gameObject.SetActive(true);
        doorCanvas.gameObject.SetActive(true);
        interactableIndicator.gameObject.SetActive(true);
    }
}
