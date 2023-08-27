using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    // GameObject with this script must has the layer "Interactable"
    [SerializeField]
    bool useSceneTransition = true;

    [SerializeField]
    GameScene sceneToLoad;

    public override void Interact()
    {
        if (useSceneTransition)
        {
            SceneTransitions.Instance.LoadScene((int)sceneToLoad);
        } else
        {
            SceneManager.LoadScene((int)sceneToLoad);
        }
    }

    public override void HoldInteract()
    {
        if (useSceneTransition)
        {
            SceneTransitions.Instance.LoadScene((int)sceneToLoad);
        } else
        {
            SceneManager.LoadScene((int)sceneToLoad);
        }
    }

    public override void ReleaseHoldInteract()
    {
        return;
    }
}
