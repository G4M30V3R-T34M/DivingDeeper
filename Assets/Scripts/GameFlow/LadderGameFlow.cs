using UnityEngine;

public class LadderGameFlow : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Collider2D col2d;

    public void Activate()
    {
        col2d.enabled = true;

        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }

    public void Deactivate()
    {
        col2d.enabled = false;

        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
    }
}
