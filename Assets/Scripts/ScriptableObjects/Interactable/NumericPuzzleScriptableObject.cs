using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
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

    [Header("Puzzle settings")]
    public string[] allStatus;
    public string winStatus;

}
