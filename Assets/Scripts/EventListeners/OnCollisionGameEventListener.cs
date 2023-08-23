using UnityEngine;
using UnityEngine.Events;
using FeTo.SOArchitecture;

[RequireComponent(typeof(Collider2D))]
public class OnCollisionGameEventListener : GameEventListener
{

    protected void OnTriggerEnter2D(Collider2D col) {
        Event.RegisterListener(this);
    }

    protected void OnTriggerExit2D(Collider2D col) {
        Event.UnregisterListener(this);
    }

    protected new void OnEnable() { }
    protected new void OnDisable() { }

}

