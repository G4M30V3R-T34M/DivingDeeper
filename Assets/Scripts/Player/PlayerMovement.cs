using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // This class do too many things
    // TODO divide responsabilities
    [SerializeField]
    PlayerMovementScriptableObject playerSettings;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Transform groundCheck;

    private float horizontal;
    private float vertical;
    private float gravityScale;

    private bool isFacingRight { get => transform.localScale.x < 0; }
    private bool isLadder = false;
    private float speedFactor = 1;
    private LayerMask groundLayer;

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

        float horizontalSpeed = horizontal * playerSettings.speed * speedFactor;
        if (isLadder) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontalSpeed, vertical * playerSettings.speed);
        }
        else {
            rb.gravityScale = gravityScale;
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
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
        } else if(collision.gameObject.layer == (int)Layer.Fear) {
            speedFactor -= playerSettings.fearDecrementFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Ladder) {
            isLadder = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        } else if (collision.gameObject.layer == (int)Layer.Fear) {
            speedFactor += playerSettings.fearDecrementFactor;
        }
    }
}
