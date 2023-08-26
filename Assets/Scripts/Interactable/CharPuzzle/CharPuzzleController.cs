using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class CharPuzzleController : MonoBehaviour
{
    [Header("Puzzle Settigns")]
    [SerializeField]
    CharPuzzleScriptableObject puzleSettings;

    [Header("Display List")]
    [SerializeField]
    CharDisplayController[] allDisplays;

    [Header("Success event")]
    [SerializeField]
    GameEvent puzzleSucceed;

    string[] currentValues;
    bool isSolved = false;

    string EMPTY_VALUE = "";

    Animator animatorController;

    private void Awake() {
        animatorController = GetComponent<Animator>();
    }

    private void Start() {
        // Check if lenght of display and solution are the same
        if(puzleSettings.solution.Length != allDisplays.Length) {
            throw new System.Exception("Number of displays different to solution elements count");
        }


        // Initialce current state to empty
        currentValues = new string[puzleSettings.solution.Length];
        for(int i= 0; i < puzleSettings.solution.Length; i++) {
            currentValues[i] = EMPTY_VALUE;
        }

        // Get random position and set it's character
        int index = Random.Range(0, currentValues.Length);
        currentValues[index] = puzleSettings.solution[index];
        UpdateAllDisplays();
    }
    private bool IsPositionInRange(int position) {
        return 0 <= position && position < currentValues.Length;
    }

    public void UpdatePuzlePosition(int position) {
        if (isSolved) {
            return;
        }
        if (!IsPositionInRange(position)) {
            throw new System.Exception($"Position {position} out of range. Range: 0 - {currentValues.Length - 1}");
        }
        UpdateAdjacent(position - 1);
        UpdatePosition(position);
        UpdateAdjacent(position + 1);
        UpdateAllDisplays();
        CheckSolution();
    }

    private void UpdatePosition(int position) {
        string newValue = currentValues[position] == EMPTY_VALUE ? puzleSettings.solution[position] : EMPTY_VALUE;
        currentValues[position] = newValue;
    }

    private void UpdateAdjacent(int position) {
        if (!IsPositionInRange(position)) {
            return;
        }
        UpdatePosition(position);
    }

    private void UpdateAllDisplays() {
        for(int i = 0; i < currentValues.Length; i++) {
            allDisplays[i].UpdateInfo(currentValues[i]);
        }
    }

    private void CheckSolution() {
        for(int i = 0; i < currentValues.Length; i++) {
            if (currentValues[i] == EMPTY_VALUE) {
                return;
            }
        }
        puzzleSucceed.Raise();
        animatorController.enabled = true;
        animatorController.SetTrigger("Succeed");
        DisableAllDisplays();
        this.enabled = false;
    }

    private void DisableAllDisplays() {
        for (int i = 0; i < allDisplays.Length; i++) {
            allDisplays[i].enabled = false;
        }
    }
}
