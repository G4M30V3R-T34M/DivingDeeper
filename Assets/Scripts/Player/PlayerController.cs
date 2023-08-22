using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    IInteractable interactable;

    private void OnTriggerEnter2D(Collider2D collision) {
        MonoBehaviour script = collision.gameObject.GetComponent<MonoBehaviour>();
        if (script is IInteractable) {
            interactable = (IInteractable)script;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        MonoBehaviour script = collision.gameObject.GetComponent<MonoBehaviour>();
        if (script is IInteractable) {
            interactable = null;
        }
    }

    public void Interact(InputAction.CallbackContext context) {
        if(context.performed && interactable != null) {
            interactable.Interact();
        }
    }
}
