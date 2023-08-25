using System.Collections.Generic;
using UnityEngine;

public class QuestManager : IQuestManager
{
    private readonly Dictionary<string, QuestScriptableObject> quests;

    public QuestManager()
    {
        quests = new Dictionary<string, QuestScriptableObject>();
        LoadQuests();
    }

    public void Complete(string id)
    {
        if (quests.TryGetValue(id, out QuestScriptableObject quest))
        {
            quest.status = QuestStatus.Completed;
            foreach (string nextId in quest.nextIds) Activate(nextId);
        }
        // else - throw ?? 
    }

    public void Activate(string id)
    {
        if (quests.TryGetValue(id, out QuestScriptableObject quest))
        {
            quest.status = QuestStatus.Available;
        }
        // else - throw ?? 
    }

    public bool IsBloqued(string id) =>
        quests.TryGetValue(id, out QuestScriptableObject quest) &&
        quest.status == QuestStatus.Bloqued;

    public bool IsAvailable(string id) =>
        quests.TryGetValue(id, out QuestScriptableObject quest) &&
        quest.status == QuestStatus.Available;

    public bool IsCompleted(string id) =>
        quests.TryGetValue(id, out QuestScriptableObject quest) &&
        quest.status == QuestStatus.Completed;

    public void ResetQuests()
    {
        quests.Clear();
        LoadQuests();
    }

    private void LoadQuests()
    {
        QuestScriptableObject[] questScriptables = Resources.LoadAll<QuestScriptableObject>("Quests");

        foreach (QuestScriptableObject quest in questScriptables)
        {
            quest.status = quest.startStatus;
            quests.Add(quest.id, quest);
#if UNITY_EDITOR
            Debug.Log($"Added quest {quest.id} with nextIds {quest.nextIds[0]} status {quest.status}");
#endif
        }
    }
}
