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
    private bool isFeared = false;
    private float endRunAwayX;
    private float speedFactor = 1;
    private LayerMask groundLayer;

    private float FEAR_HORIZONTAL_VELOCITY = 1.2f;

    private void Start() {
        groundLayer = LayerMask.GetMask(Layer.Ground.ToString());
        gravityScale = rb.gravityScale;
    }

    void Update() {
        if (!isFacingRight && horizontal > 0f ||
            isFacingRight && horizontal < 0f) {
            Flip();
        }

        if (isFeared) {
            CheckIfTargetAchieved();
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

    private void CheckIfTargetAchieved() {
        if (isFacingRight && transform.position.x > endRunAwayX) {
            ResetFearSpeed();
        }
        if (!isFacingRight && transform.position.x < endRunAwayX) {
            ResetFearSpeed();
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
        if (isFeared) {
            return;
        }
        horizontal = context.ReadValue<Vector2>().x;
        if (isLadder) {
            vertical = context.ReadValue<Vector2>().y;
        } else {
            vertical = 0f;
        }
    }

    public void Jump(InputAction.CallbackContext context) {
        if (isFeared) {
            return;
        }
        if (context.performed && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, playerSettings.jumpPower);
        }

        if (context.canceled && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void SetFearSpeed(float xPosition) {
        horizontal = FEAR_HORIZONTAL_VELOCITY;
        if (isFacingRight) {
            horizontal *= -1f;
            endRunAwayX = xPosition - playerSettings.runAwayDistance;
        }
        else {
            endRunAwayX = xPosition + playerSettings.runAwayDistance;
        }
    }

    private void ResetFearSpeed() {
        isFeared = false;
        horizontal = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Ladder) {
            isLadder = true;
        } else if(collision.gameObject.layer == (int)Layer.Slowdown) {
            speedFactor -= playerSettings.fearDecrementFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer == (int)Layer.Ladder) {
            isLadder = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        } else if (collision.gameObject.layer == (int)Layer.Slowdown) {
            speedFactor += playerSettings.fearDecrementFactor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == (int)Layer.Fear) {
            isFeared = true;
            SetFearSpeed(collision.transform.position.x);
        }
    }
}
