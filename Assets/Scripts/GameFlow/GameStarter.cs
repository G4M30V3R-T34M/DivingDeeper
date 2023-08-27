using System.Collections;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    ConversationScriptableObject conversation;

    [SerializeField]
    QuestScriptableObject quest;

    [SerializeField]
    GameScene nextScene;

    private void Start()
    {
        ConversationPlayer.Instance.Play(conversation, quest);
    }

    public void QuestCompleted(string id)
    {
        if (id == quest.Id)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        SceneTransitions.Instance.LoadScene((int)nextScene);
    }
}
