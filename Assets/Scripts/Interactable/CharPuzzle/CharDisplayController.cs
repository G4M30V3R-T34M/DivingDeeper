using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharDisplayController: Interactable
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    int position;

    [SerializeField]
    CharPuzzleController puzzle;

    Collider2D displayCollider;

    protected override void Awake() {
        base.Awake();
        displayCollider = GetComponent<Collider2D>();
    }

    public override void Interact() {
        puzzle.UpdatePuzlePosition(position);
    }

    public override void HoldInteract() {
        puzzle.UpdatePuzlePosition(position);
    }

    public override void ReleaseHoldInteract() {
        return;
    }

    public void UpdateInfo(string value) {
        text.SetText(value);
    }

    private void OnDisable() {
        displayCollider.enabled = false;
    }
}
