using FeTo.SOArchitecture;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Box : Interactable
{
    [SerializeField]
    GameEventListener releaseListener;
    [SerializeField]
    BoxScriptableObject boxSettings;

    Transform playerTransform;

    private float onHoldYOffset = 0.6f;

    private Rigidbody2D rb;
    private Collider2D triggerCollider;
    private Animator animatorController;

    protected override void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        triggerCollider = gameObject.GetComponent<Collider2D>();
        animatorController = gameObject.GetComponent<Animator>();
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
        // Ensure box is well oriented
        Vector3 localScale = transform.localScale;
        localScale.x = 1f;
        transform.localScale = localScale;
    }

    public string GetID() {
        return boxSettings.id;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == (int)Layer.Player) {
            playerTransform = collision.gameObject.transform;
        } else if(collision.gameObject.layer == (int)Layer.Placeholder) {
            transform.position = collision.transform.position;
        }

        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        playerTransform = null;
        base.OnTriggerExit2D(collision);
    }

    private void OnDisable() {
        // I know this is criminal but it's a game jam!
        triggerCollider.enabled = false;
    }

    private void OnEnable() {
        triggerCollider.enabled = true;
    }

    public void SucceedAnimation() {
        animatorController.enabled = true;
        animatorController.SetTrigger("Succeed");
    }
}
