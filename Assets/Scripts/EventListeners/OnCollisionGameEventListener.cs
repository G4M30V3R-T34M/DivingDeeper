using UnityEngine;
using UnityEngine.Events;
using FeTo.SOArchitecture;

public class OnCollisionGameEventListener : GameEventListener
{

    protected void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.layer == (int)Layer.Player) {
            Event.RegisterListener(this);
        }
    }

    protected void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.layer == (int)Layer.Player) {
            Event.UnregisterListener(this);
        }
    }

    protected new void OnEnable() { }
    protected new void OnDisable() { }

}

