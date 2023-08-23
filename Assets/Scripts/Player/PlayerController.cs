using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameEvent playerInteractEvent;
    [SerializeField]
    private GameEvent playerHoldEvent;
    [SerializeField]
    private GameEvent playerHoldReleaseEvent;

    private bool isHolding = false;

    public void Interact(InputAction.CallbackContext context) {
        if(context.interaction is PressInteraction) {
            if (context.performed) {
                playerInteractEvent.Raise();
            }
            return;
        }
        if(context.interaction is HoldInteraction) {
            if (context.performed) {
                isHolding = true;
                playerHoldEvent.Raise();
            }
            if (context.canceled && isHolding) {
                isHolding = false;
                playerHoldReleaseEvent.Raise();
            }
        }
    }
}
