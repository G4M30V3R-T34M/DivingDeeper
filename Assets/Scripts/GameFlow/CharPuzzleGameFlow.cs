using UnityEngine;

public class CharPuzzleGameFlow : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] spriteRenderers;

    [SerializeField]
    Collider2D[] colliders;

    [SerializeField]
    Color activeColor, inactiveColor;

    public void Activate()
    {
        foreach (var col2d in colliders)
        {
            col2d.enabled = true;
        }

        foreach (var sprite in spriteRenderers)
        {
            sprite.color = activeColor;
        }
    }

    public void Deactivate()
    {
        foreach (var col2d in colliders)
        {
            col2d.enabled = false;
        }

        foreach (var sprite in spriteRenderers)
        {
            sprite.color = inactiveColor;
        }

    }
}
