using UnityEngine;

public class GameDialogueConditional : MonoBehaviour
{

    [SerializeField]
    QuestScriptableObject quest;

    [SerializeField]
    QuestScriptableObject conditionalQuest;

    [SerializeField]
    ConversationScriptableObject trueConditionConversation, falseConditionConversation;

    public void StartDialogue()
    {
        if (QuestManager.Instance.IsCompleted(conditionalQuest.Id))
        {
            ConversationPlayer.Instance.Play(trueConditionConversation, quest);
        } else
        {
            ConversationPlayer.Instance.Play(falseConditionConversation, quest);
        }
    }
}
