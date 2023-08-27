using UnityEngine;

public class QuestCompleteInteraction : MonoBehaviour
{
    [SerializeField]
    QuestScriptableObject quest;

    public void Complete()
    {
        QuestManager.Instance.Complete(quest.Id);
    }
}
