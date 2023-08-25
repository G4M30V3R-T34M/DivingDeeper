using FeTo.SOArchitecture;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Box : Interactable
{
    [SerializeField]
    GameEventListener releaseListener;

    Transform playerTransform;

    private float onHoldYOffset = 0.6f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

#if UNITY_EDITOR
        base.Awake();
#endif
    }

    public override void Interact()
    {
        return;
    }

    public override void HoldInteract()
    {
        if (playerTransform)
        {
            rb.isKinematic = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + onHoldYOffset);
            transform.parent = playerTransform;
            rb.simulated = false;
            releaseListener.enabled = true;
        }
    }

    public override void ReleaseHoldInteract()
    {
        transform.parent = null;
        rb.simulated = true;
        rb.isKinematic = false;
        releaseListener.enabled = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        playerTransform = collision.gameObject.transform;
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        playerTransform = null;
        base.OnTriggerExit2D(collision);
    }
}
