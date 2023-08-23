using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterModifier : Interactable
{
    [SerializeField]
    GameEvent modifierEvent;

    public override void Interact() {
        print("Raised");
        modifierEvent.Raise();
    }

    public override void HoldInteract() {
        return;
    }

    public override void ReleaseHoldInteract() {
        return;
    }

    public void AssignGameEvent(GameEvent newEvent) {
        modifierEvent = newEvent;
    }
}
