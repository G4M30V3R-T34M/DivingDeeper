using UnityEngine;

public class CounterScreen : Interactable
{
    [SerializeField]
    NumericPuzzleScriptableObject puzzleSettings;

    string currentStatus;
    int index;

    protected override void Start() {
        index = 0;
        currentStatus = puzzleSettings.allStatus[index];
        UpdateText();
        base.Start();
    }

    public override void Interact() {
        //currentStatus == winStatus ? puzzleSucceed.Raise() : puzzleNotSucceed.Raise();
        if (currentStatus == puzzleSettings.winStatus) {
            puzzleSettings.puzzleSucceed.Raise();
        } else {
            puzzleSettings.puzzleFail.Raise();
        }
    }

    public override void HoldInteract() {
        Interact();
    }

    public override void ReleaseHoldInteract() {
        return;
    }

    public void PreviousState() {
        index = index == 0 ? puzzleSettings.allStatus.Length-1 : index - 1;
        currentStatus = puzzleSettings.allStatus[index];
        UpdateText();
    }

    public void NextState() {
        index = index == puzzleSettings.allStatus.Length-1 ? 0 : index + 1;
        currentStatus = puzzleSettings.allStatus[index];
        UpdateText();
    }

    public void UpdateText() {
        puzzleSettings.screenTextUpdateEvent.Raise(currentStatus);
    }
}
