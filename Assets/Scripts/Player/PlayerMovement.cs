using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerMovementScriptableObject playerSettings;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Transform groundCheck;

    private SpriteRenderer spriteRenderer;

    private float horizontal;
    private float vertical;
    private float gravityScale;

    private bool isFacingRight { get => spriteRenderer.flipX; }
    private bool isLadder = false;
    private LayerMask groundLayer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        groundLayer = LayerMask.GetMask(Layer.Ground.ToString());
        gravityScale = rb.gravityScale;
    }

    void Update() {
        if (!isFacingRight && horizontal > 0f ||
            isFacingRight && horizontal < 0f) {
            Flip();
        }
    }
    private void FixedUpdate() {
        if (isLadder) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * playerSettings.speed, vertical * playerSettings.speed);
        }
        else {
            rb.gravityScale = gravityScale;
            rb.velocity = new Vector2(horizontal * playerSettings.speed, rb.velocity.y);
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Move(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
        if (isLadder) {
            vertical = context.ReadValue<Vector2>().y;
        } else {
            vertical = 0f;
        }
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, playerSettings.jumpPower);
        }

        if (context.canceled && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Ladder) {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Ladder) {
            isLadder = false;
        }
    }
}
