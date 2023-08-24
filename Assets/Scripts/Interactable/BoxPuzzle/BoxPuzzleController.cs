using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleController : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField]
    BoxPuzzleScriptableObject puzzleSettings;

    [Header("Configurations")]
    [SerializeField]
    BoxPlaceholder[] placeholders;
    [SerializeField]
    GameEvent puzzleSucceed;

    string[] currentValues;

    string EMPTY_VALUE = "";

    private void Start() {
        // Check if lenght of display and solution are the same
        if (puzzleSettings.solution.Length != placeholders.Length) {
            throw new System.Exception("Number of displays different to solution elements count");
        }

        // Initialce current state to empty
        currentValues = new string[puzzleSettings.solution.Length];
        for (int i = 0; i < puzzleSettings.solution.Length; i++) {
            currentValues[i] = EMPTY_VALUE;
        }
    }

    public void SetValue(string id, int position) {
        if (!IsPositionInRange(position)) {
            throw new System.Exception($"Position {position} out of range. Range: 0 - {currentValues.Length - 1}");
        }
        currentValues[position] = id;
        CheckSolution();
    }

    public void UnsetValue(int position) {
        if (!IsPositionInRange(position)) {
            throw new System.Exception($"Position {position} out of range. Range: 0 - {currentValues.Length - 1}");
        }
        currentValues[position] = null;
    }

    private void CheckSolution() {
        for (int i = 0; i < currentValues.Length; i++) {
            if (currentValues[i] == EMPTY_VALUE) {
                return;
            }
            if (currentValues[i] != puzzleSettings.solution[i].id) {
                return;
            }
        }
        puzzleSucceed.Raise();
        BlockResult();
    }

    private void BlockResult() {
        for(int i = 0; i < placeholders.Length; i++) {
            placeholders[i].BlockPlacedBox();
            placeholders[i].SucceedAnimation();
        }
    }

    private bool IsPositionInRange(int position) {
        return 0 <= position && position < currentValues.Length;
    }
}
