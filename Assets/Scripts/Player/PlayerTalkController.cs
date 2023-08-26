using FeTo.SOArchitecture;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTalkController : MonoBehaviour
{
    [SerializeField]
    GameEvent TalkGameEvent;

    [SerializeField]
    float minTimeBetweenTalkInteractions = 0.5f;

    bool talkAvailable = true;

    public void TalkPerformed(InputAction.CallbackContext context)
    {
        if (context.performed && talkAvailable)
        {
            TalkGameEvent.Raise();
            talkAvailable = false;
            StartCoroutine(TalkCoolDown());
        }
    }

    private IEnumerator TalkCoolDown()
    {
        yield return new WaitForSeconds(minTimeBetweenTalkInteractions);
        talkAvailable = true;
    }
}
