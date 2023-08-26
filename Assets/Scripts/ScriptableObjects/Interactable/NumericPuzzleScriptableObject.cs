using FeTo.SOArchitecture;
using UnityEngine;

[CreateAssetMenu(fileName = "NumericPuzzleScriptableObject", menuName = "Scriptables/NumericPuzzleScriptableObject")]
public class NumericPuzzleScriptableObject : ScriptableObject
{
    [Header("Events")]
    public GameEvent nextStateEvent;
    public GameEvent previousStateEvent;
    public GameEvent puzzleSucceed;
    public GameEvent puzzleFail;
    public StringGameEvent screenTextUpdateEvent;

    [Header("Quest")]
    public QuestScriptableObject quest;

    [Header("Puzzle settings")]
    public string[] allStatus;
    public string winStatus;

}
