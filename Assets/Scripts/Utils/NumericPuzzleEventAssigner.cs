using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericPuzzleEventAssigner : MonoBehaviour
{
    [Header("Puzzle Scriptable")]
    [SerializeField]
    NumericPuzzleScriptableObject puzzleSettings;

    [Header("Screen Modifiers")]
    [SerializeField]
    CounterModifier previousModifier;
    [SerializeField]
    CounterModifier nextModifier;

    [Header("Event listener")]
    [SerializeField]
    GameEventListener previousEventListener;
    [SerializeField]
    GameEventListener nextEventListener;

    private void Awake() {
        previousModifier.AssignGameEvent(puzzleSettings.previousStateEvent);
        nextModifier.AssignGameEvent(puzzleSettings.nextStateEvent);

        nextEventListener.Event = puzzleSettings.nextStateEvent;
        print("Enable next");
        nextEventListener.enabled = true;
        previousEventListener.Event = puzzleSettings.previousStateEvent;
        print("Enable prev");
        previousEventListener.enabled = true;
    }
}
