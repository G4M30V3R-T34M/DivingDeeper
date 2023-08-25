using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestScriptableObject", menuName = "Scriptables/QuestScriptableObject")]
public class QuestScriptableObject : ScriptableObject
{
    public int previousQuestsAmount = 1;
    public QuestStatus startStatus = QuestStatus.Bloqued;
    public List<QuestScriptableObject> nextQuests;

    public string Id { get => this.name; }
}
