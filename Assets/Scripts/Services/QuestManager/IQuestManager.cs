public interface IQuestManager
{
    public void ResetQuests();
    public bool IsBloqued(string id);
    public bool IsAvailable(string id);
    public bool IsCompleted(string id);
    public void Complete(string id);
}
