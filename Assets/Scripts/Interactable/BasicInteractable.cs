using UnityEngine;

public class BasicInteractable : Interactable
{
    [SerializeField]
    QuestScriptableObject quest;

    public override void HoldInteract()
    {
        QuestManager.Instance.Complete(quest.Id);
    }

    public override void Interact()
    {
        QuestManager.Instance.Complete(quest.Id);
    }

    public override void ReleaseHoldInteract()
    {
        return;
    }
}
