using FeTo.Singleton;
using FeTo.SOArchitecture;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : SingletonPersistent<QuestManager>, IQuestManager
{
    [SerializeField]
    StringGameEvent questAvailable, questCompleted;

    private Dictionary<string, QuestData> quests;

    protected override void Awake()
    {
        base.Awake();
        quests = new Dictionary<string, QuestData>();
        LoadQuests();
    }

    /*** TPM ***/
    public QuestData GetQuest(string id) => quests[id];
    /*** END TMP ***/

    public void Complete(string id)
    {
        quests[id].Status = QuestStatus.Completed;
        questCompleted.Raise(id);
        foreach (string nextQuestId in quests[id].NextQuests) { AdvanceLockedQuest(nextQuestId); }
    }

    private void AdvanceLockedQuest(string id)
    {
        quests[id].PreviousQuestsCompleted += 1;
        if (quests[id].IsUnlockable())
        {
            quests[id].Status = QuestStatus.Available;
            questAvailable.Raise(id);
        }
    }

    public bool IsBloqued(string id) =>
        quests.TryGetValue(id, out QuestData quest) &&
        quest.Status == QuestStatus.Bloqued;

    public bool IsAvailable(string id) =>
        quests.TryGetValue(id, out QuestData quest) &&
        quest.Status == QuestStatus.Available;

    public bool IsCompleted(string id) =>
        quests.TryGetValue(id, out QuestData quest) &&
        quest.Status == QuestStatus.Completed;

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
            quests.Add(quest.Id, new QuestData(
                quest.Id,
                quest.previousQuestsAmount,
                quest.startStatus,
                quest.nextQuests.Select(quest => quest.Id).ToList()));
        }
    }
}
