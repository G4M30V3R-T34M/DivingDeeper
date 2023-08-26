using UnityEngine;

public class HumanQuestBehaviour : MonoBehaviour
{
    HumanController humanController;

    [SerializeField]
    QuestScriptableObject reduceFear, deleteFear;

    protected void Start()
    {
        humanController = GetComponent<HumanController>();
        CheckQuests();
    }

    private void CheckQuests()
    {
        if (QuestManager.Instance.IsCompleted(reduceFear.Id))
        {
            ReduceFear();
        }

        if (QuestManager.Instance.IsCompleted(deleteFear.Id))
        {
            DeleteFear();
        }
    }

    private void ReduceFear()
    {
        humanController.LoseFearArea();
    }

    private void DeleteFear()
    {
        humanController.LoseSlowdownArea();
    }

    public void QuestCompleted(string questId)
    {
        if (questId == reduceFear.Id)
        {
            ReduceFear();
        }

        if (questId == deleteFear.Id)
        {
            DeleteFear();
        }
    }




}
