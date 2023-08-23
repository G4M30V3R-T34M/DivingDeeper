using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer interactableFeedback;

    float currentHue;
    float currentSaturation;
    float currentValue;

    float SATURATION_VARIATION = 50f;

    private void Start() {
        Color.RGBToHSV(
            interactableFeedback.color,
            out currentHue, 
            out currentSaturation,
            out currentValue
        );
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // As "Interactable" layer just collide with player we don't need to check
        // collision layer
        if (interactableFeedback != null) {
            currentSaturation += SATURATION_VARIATION;
            interactableFeedback.color = Color.HSVToRGB(currentHue, currentSaturation, currentValue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // As "Interactable" layer just collide with player we don't need to check
        // collision layer
        if (interactableFeedback != null) {
            currentSaturation -= SATURATION_VARIATION;
            interactableFeedback.color = Color.HSVToRGB(currentHue, currentSaturation, currentValue);
        }
    }

    public abstract void Interact();
}
