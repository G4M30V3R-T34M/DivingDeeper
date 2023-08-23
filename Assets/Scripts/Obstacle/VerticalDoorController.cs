using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VerticalDoorController : MonoBehaviour
{
    bool isOpen;
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        isOpen = false;
    }

    public void OpenDoor() {
        if (!isOpen) {
            animator.SetTrigger("Open");
            isOpen = true;
        }
    }
}
