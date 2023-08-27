using UnityEngine;

public class GameDialogue : MonoBehaviour
{
    [SerializeField]
    ConversationScriptableObject conversation;

    [SerializeField]
    QuestScriptableObject quest;

    public void StartDialogue()
    {
        ConversationPlayer.Instance.Play(conversation, quest);
    }
}
