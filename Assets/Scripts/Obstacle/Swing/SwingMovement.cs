using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SwingMovement : MonoBehaviour
{
    [SerializeField]
    SwingScriptableObject swingSettings;

    float maxRightPosition;
    float maxLeftPosition;

    private float currentSpeed;

    private void Start() {
        currentSpeed = swingSettings.speed;
        maxLeftPosition = transform.position.x - swingSettings.distanceFromCenter;
        maxRightPosition = transform.position.x + swingSettings.distanceFromCenter;
        print(maxRightPosition);
        StartCoroutine(Swing());
    }

    private IEnumerator Swing() {
        while (true) {
            if(HasReachedLeft() || HasReachedRight()) {
                currentSpeed = -currentSpeed;
            }
            transform.position = new Vector2(transform.position.x + currentSpeed * Time.deltaTime, transform.position.y);
            yield return null;
        }
    }

    private bool HasReachedLeft() {
        return transform.position.x <= maxLeftPosition;
    }

    private bool HasReachedRight() {
        return transform.position.x >= maxRightPosition;
    }
}
