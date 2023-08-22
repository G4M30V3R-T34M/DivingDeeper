using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // GameObject with this script must has the layer "Interactable"

    [SerializeField]
    GameScene sceneToLoad;
    [SerializeField]
    GameObject interactableFeedback;

    public void Interact() {
        SceneManager.LoadScene((int)sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // As "Interactable" layer just collide with player we don't need to check
        // collision layer
        interactableFeedback.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // As "Interactable" layer just collide with player we don't need to check
        // collision layer
        interactableFeedback.SetActive(false);
    }
}
