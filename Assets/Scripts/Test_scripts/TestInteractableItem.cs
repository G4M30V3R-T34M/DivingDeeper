using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject interactableFeedback;

    public void Interact() {
        Debug.Log("Inteacted");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Player) {
            interactableFeedback.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Player) {
            interactableFeedback.SetActive(false);
        }
    }
}
