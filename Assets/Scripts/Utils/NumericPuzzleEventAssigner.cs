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
    [SerializeField]
    StringGameEventListener textUpdateEventListener;

    private void Awake() {
        previousModifier.AssignGameEvent(puzzleSettings.previousStateEvent);
        nextModifier.AssignGameEvent(puzzleSettings.nextStateEvent);

        nextEventListener.Event = puzzleSettings.nextStateEvent;
        nextEventListener.enabled = true;

        previousEventListener.Event = puzzleSettings.previousStateEvent;
        previousEventListener.enabled = true;

        textUpdateEventListener.Event = puzzleSettings.screenTextUpdateEvent;
        textUpdateEventListener.enabled = true;
    }
}
