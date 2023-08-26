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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        slowdownArea.SetActive(false);
        fearArea.SetActive(true);
    }

    public void LoseFearArea()
    {
        fearArea.SetActive(false);
        slowdownArea.SetActive(true);
    }

    public void LoseSlowdownArea()
    {
        slowdownArea.SetActive(false);
        fearArea.SetActive(false);
    }
}
