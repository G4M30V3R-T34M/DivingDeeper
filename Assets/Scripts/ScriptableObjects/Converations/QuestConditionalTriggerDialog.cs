using UnityEngine;

[CreateAssetMenu(fileName = "QuestConditionalTriggerDialog", menuName = "Scriptables/QuestConditionalTriggerDialog")]
public class QuestConditionalTriggerDialog : ScriptableObject
{
    public QuestScriptableObject triggerQuest;
    public QuestScriptableObject conditionalQuest;
    public ConversationScriptableObject conditionalCompletedConversation;
    public ConversationScriptableObject conditionalFailedConversation;
}
