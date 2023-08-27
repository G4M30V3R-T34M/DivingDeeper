using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneLoad : MonoBehaviour
{
    [SerializeField]
    QuestScriptableObject quest;

    public void LoadWin(string questId) {
        if(questId == quest.Id) {
            SceneTransitions.Instance.LoadScene(5);
        }
    }
}
