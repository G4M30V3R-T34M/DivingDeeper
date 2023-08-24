using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SwingController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collision.gameObject.transform.parent = null;
    }
}
