using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConversationScriptableObject", menuName = "Scriptables/ConversationScriptableObject")]
public class ConversationScriptableObject : ScriptableObject
{
    public List<ConversationPartScriptableObject> conversationParts;
}
