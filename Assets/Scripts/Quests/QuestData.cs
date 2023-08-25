using System.Collections.Generic;

public class QuestData
{
    private string id;
    private int previousQuestsAmount;
    private int previousQuestsCompleted;
    private QuestStatus status;
    private List<string> nextQuests;

    public int PreviousQuestsAmount { get => previousQuestsAmount; }

    public string Id { get => id; }
    public int PreviousQuestsCompleted
    {
        get => previousQuestsCompleted;
        set => previousQuestsCompleted = value;
    }
    public QuestStatus Status
    {
        get => status;
        set => status = value;
    }
    public List<string> NextQuests { get => nextQuests; }

    public QuestData(string id, int previousQuests, QuestStatus startingStatus, List<string> nextQuests)
    {
        this.id = id;
        this.previousQuestsAmount = previousQuests;
        this.previousQuestsCompleted = 0;
        this.status = startingStatus;
        this.nextQuests = nextQuests;
    }

    public bool IsUnlockable() =>
        previousQuestsAmount == previousQuestsCompleted;
}
