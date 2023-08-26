using UnityEngine;

[CreateAssetMenu(fileName = "ConversationPartScriptableObject", menuName = "Scriptables/ConversationPartScriptableObject")]
public class ConversationPartScriptableObject : ScriptableObject
{
    public Actors actor;
    public string text;
}
