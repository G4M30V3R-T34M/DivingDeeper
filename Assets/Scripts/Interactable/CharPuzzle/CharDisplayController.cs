using TMPro;
using UnityEngine;

public class CharDisplayController : Interactable
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    int position;

    [SerializeField]
    CharPuzzleController puzzle;

    Collider2D displayCollider;

    protected override void Awake()
    {
        displayCollider = GetComponent<Collider2D>();
#if UNITY_EDITOR
        base.Awake();
#endif
    }

    public override void Interact()
    {
        puzzle.UpdatePuzlePosition(position);
    }

    public override void HoldInteract()
    {
        puzzle.UpdatePuzlePosition(position);
    }

    public override void ReleaseHoldInteract()
    {
        return;
    }

    public void UpdateInfo(string value)
    {
        text.SetText(value);
    }

    private void OnDisable()
    {
        displayCollider.enabled = false;
    }

    private void OnEnable() {
        displayCollider.enabled = true;
    }
}
