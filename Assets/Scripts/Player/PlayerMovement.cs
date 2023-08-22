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
    private bool isFacingRight;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontal * playerSettings.speed, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f) {
            Flip();
        } else if (isFacingRight && horizontal < 0f) {
            Flip();
        }
    }

    private bool IsGrounded() {
        LayerMask layer = LayerMask.GetMask(Layer.Ground.ToString());
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = isFacingRight;
    }

    public void Move(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, playerSettings.jumpPower);
        }

        if (context.canceled && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}
