using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    List<QuestTriggerDialog> basicQuestDialogs;

    [SerializeField]
    List<QuestConditionalTriggerDialog> conditionalQuestDialogs;

    private Dictionary<string, QuestTriggerDialog> basicQuests = new();
    private Dictionary<string, QuestConditionalTriggerDialog> conditionalQuests = new();

    private void Awake()
    {
        foreach (QuestTriggerDialog dialog in basicQuestDialogs)
        {
            basicQuests.Add(dialog.quest.Id, dialog);
        }

        foreach (QuestConditionalTriggerDialog dialog in conditionalQuestDialogs)
        {
            conditionalQuests.Add(dialog.triggerQuest.Id, dialog);
        }
    }

    public void CheckQuestCompleted(string questId)
    {
        if (basicQuests.TryGetValue(questId, out QuestTriggerDialog questTrigger))
        {
            ConversationPlayer.Instance.Play(questTrigger.conversation);
        } else if (conditionalQuests.TryGetValue(questId, out QuestConditionalTriggerDialog questConditionalTrigger))
        {
            if (QuestManager.Instance.IsCompleted(questConditionalTrigger.conditionalQuest.Id))
            {
                ConversationPlayer.Instance.Play(questConditionalTrigger.conditionalCompletedConversation);
            } else
            {
                ConversationPlayer.Instance.Play(questConditionalTrigger.conditionalFailedConversation);
            }
        }
    }

}
