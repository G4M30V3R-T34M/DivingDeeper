using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    // GameObject with this script must has the layer "Interactable"

    [SerializeField]
    GameScene sceneToLoad;

    public override void Interact() {
        SceneManager.LoadScene((int)sceneToLoad);
    }

    public override void HoldInteract() {
        SceneManager.LoadScene((int)sceneToLoad);
    }

    public override void ReleaseHoldInteract() {
        return;
    }
}
