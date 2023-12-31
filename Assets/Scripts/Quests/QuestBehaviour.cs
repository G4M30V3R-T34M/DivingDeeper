using UnityEngine;
using UnityEngine.Events;

public class QuestBehaviour : MonoBehaviour
{
    [SerializeField]
    QuestScriptableObject quest;

    [SerializeField]
    UnityEvent OnBlocked;

    [SerializeField]
    UnityEvent OnAvailable;

    [SerializeField]
    UnityEvent OnCompleted;

    IQuestManager questManager;

    private void Start()
    {
        if (quest == null) return;

        questManager = QuestManager.Instance;
        if (questManager.IsBloqued(quest.Id))
        {
            OnBlocked?.Invoke();
        } else if (questManager.IsAvailable(quest.Id))
        {
            OnAvailable?.Invoke();
        } else if (questManager.IsCompleted(quest.Id))
        {
            OnCompleted?.Invoke();
        }
    }

    public void QuestAvailable(string questId)
    {
        print(questId);
        print(quest.Id);
        print(OnAvailable);
        if (quest == null) return;
        if (questId == quest.Id) { OnAvailable?.Invoke(); }
    }

    public void QuestCompleted(string questId)
    {
        if (quest == null) return;
        if (questId == quest.Id) { OnCompleted?.Invoke(); }
    }
}
