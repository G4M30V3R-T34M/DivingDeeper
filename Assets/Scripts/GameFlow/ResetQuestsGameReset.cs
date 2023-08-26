using UnityEngine;

public class ResetQuestsGameReset : MonoBehaviour
{
    protected void Start()
    {
        QuestManager.Instance.ResetQuests();
    }
}
