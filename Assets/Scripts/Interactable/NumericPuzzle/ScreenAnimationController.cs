using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ScreenAnimationController : MonoBehaviour
{
    bool isSucceed;
    Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        isSucceed = false;
    }

    public void Fail() {
        if (!isSucceed) {
            animator.enabled = true;
            animator.SetTrigger("Fail");
        }
    }

    public void Succeed() {
        if (!isSucceed) {
            animator.enabled = true;
            animator.SetTrigger("Succeed");
            isSucceed = true;
        }
    }

    public void DisableAnimator() {
        animator.enabled = false;
    }
}
