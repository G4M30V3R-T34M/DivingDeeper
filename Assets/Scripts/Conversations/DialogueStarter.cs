using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField]
    ConversationScriptableObject conversation;

    public void StartDialog()
    {
        ConversationPlayer.Instance.Play(conversation);
    }
}
