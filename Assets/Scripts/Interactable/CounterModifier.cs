using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterModifier : Interactable
{
    [SerializeField]
    GameEvent modifierEvent;

    public override void Interact() {
        modifierEvent.Raise();
    }

    public override void HoldInteract() {
        modifierEvent.Raise(); ;
    }

    public override void ReleaseHoldInteract() {
        return;
    }

    public void AssignGameEvent(GameEvent newEvent) {
        modifierEvent = newEvent;
    }
}
