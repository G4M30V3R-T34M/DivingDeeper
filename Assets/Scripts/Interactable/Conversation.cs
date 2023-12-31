using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : Interactable
{
    [SerializeField]
    GameEvent conversationEvent;
    public override void Interact() {
        conversationEvent.Raise();
    }

    public override void HoldInteract() {
        conversationEvent.Raise();
    }

    public override void ReleaseHoldInteract() {
        return;
    }
}
