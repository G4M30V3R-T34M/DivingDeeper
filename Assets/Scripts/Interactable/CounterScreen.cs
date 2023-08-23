using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CounterScreen : Interactable
{
    [SerializeField]
    NumericPuzzleScriptableObject puzzleSettings;

    string currentStatus;
    int index;

    private void Start() {
        index = 0;
        currentStatus = puzzleSettings.allStatus[index];
    }

    public override void Interact() {
        //currentStatus == winStatus ? puzzleSucceed.Raise() : puzzleNotSucceed.Raise();
        if (currentStatus == puzzleSettings.winStatus) {
            puzzleSettings.puzzleSucceed.Raise();
            print("Succeed");
        } else {
            puzzleSettings.puzzleFail.Raise();
            print("fail");
        }
    }

    public override void HoldInteract() {
        Interact();
    }

    public override void ReleaseHoldInteract() {
        return;
    }

    public void PreviousState() {
        print("Prev state");
        index = index == 0 ? puzzleSettings.allStatus.Length-1 : index - 1;
        currentStatus = puzzleSettings.allStatus[index];
        Debug.Log(currentStatus);
    }

    public void NextState() {
        print("next state");
        index = index == puzzleSettings.allStatus.Length-1 ? 0 : index + 1;
        currentStatus = puzzleSettings.allStatus[index];
        Debug.Log(currentStatus);
    }

}
