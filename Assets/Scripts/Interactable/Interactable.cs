using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer interactableFeedback;

    float currentHue;
    float currentSaturation;
    float currentValue;

    float SATURATION_VARIATION = 50f;

    protected virtual void Awake()
    {
#if UNITY_EDITOR
        if (gameObject.layer != (int)Layer.Interactable)
        {
            throw new Exception(
                String.Format("Layer of {0} must be Interactable", gameObject.name)
            );
        }
#endif
    }

    protected virtual void Start()
    {
        Color.RGBToHSV(
            interactableFeedback.color,
            out currentHue,
            out currentSaturation,
            out currentValue
        );
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactableFeedback != null && collision.gameObject.layer == (int)Layer.Player)
        {
            currentSaturation += SATURATION_VARIATION;
            interactableFeedback.color = Color.HSVToRGB(currentHue, currentSaturation, currentValue);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        // As "Interactable" layer just collide with player we don't need to check
        // collision layer
        if (interactableFeedback != null && collision.gameObject.layer == (int)Layer.Player)
        {
            currentSaturation -= SATURATION_VARIATION;
            interactableFeedback.color = Color.HSVToRGB(currentHue, currentSaturation, currentValue);
        }
    }

    public abstract void Interact();
    public abstract void HoldInteract();
    public abstract void ReleaseHoldInteract();
}
