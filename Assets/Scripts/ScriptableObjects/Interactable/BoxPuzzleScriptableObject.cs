using UnityEngine;

[CreateAssetMenu(fileName = "BoxPuzzleScriptableObject", menuName = "Scriptables/BoxPuzzleScriptableObject")]
public class BoxPuzzleScriptableObject : ScriptableObject
{
    public BoxScriptableObject[] solution;
}
