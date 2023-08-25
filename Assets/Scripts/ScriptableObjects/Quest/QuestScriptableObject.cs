using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestScriptableObject", menuName = "Scriptables/QuestScriptableObject")]
public class QuestScriptableObject : ScriptableObject
{
    public string id;
    public List<string> nextIds;
    public QuestStatus status = QuestStatus.Bloqued;
    public QuestStatus startStatus = QuestStatus.Bloqued;
}
