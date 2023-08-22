using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameEvent playerInteractEvent;

    public void Interact(InputAction.CallbackContext context) {
        if(context.performed) {
            playerInteractEvent.Raise();
        }
    }
}
