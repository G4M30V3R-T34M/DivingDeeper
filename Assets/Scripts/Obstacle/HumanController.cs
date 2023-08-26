using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HumanController : MonoBehaviour
{
    [SerializeField]
    GameObject fearArea;
    [SerializeField]
    GameObject slowdownArea;

    SpriteRenderer spriteRenderer;
    public bool isFacingRight { get => spriteRenderer.flipX; }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        slowdownArea.SetActive(false);
        fearArea.SetActive(true);
    }

    public void LoseFearArea() {
        fearArea.SetActive(false);
        slowdownArea.SetActive(true);
    }

    public void LoseSlowdownArea() {
        slowdownArea.SetActive(false);
    }
}
