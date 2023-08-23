using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Box : Interactable
{
    Transform playerTransform;

    private float onHoldYOffset = 0.6f;

    private Rigidbody2D rb;
    private float mass;

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mass = rb.mass;
    }

    public override void Interact() {
        return;
    }

    public override void HoldInteract() {
        if (playerTransform) {
            rb.isKinematic = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + onHoldYOffset);
            transform.parent = playerTransform;
            rb.simulated = false;
        }
    }

    public override void ReleaseHoldInteract() {
        transform.parent = null;
        rb.simulated = true;
        rb.isKinematic = false;
        rb.mass = mass;
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        playerTransform = collision.gameObject.transform;
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision) {
        playerTransform = null;
        base.OnTriggerExit2D(collision);
    }
}
