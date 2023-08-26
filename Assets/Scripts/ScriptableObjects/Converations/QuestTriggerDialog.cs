using UnityEngine;

[CreateAssetMenu(fileName = "QuestTriggerDialog", menuName = "Scriptables/QuestTriggerDialog")]
public class QuestTriggerDialog : ScriptableObject
{
    public QuestScriptableObject quest;
    public ConversationScriptableObject conversation;
}
