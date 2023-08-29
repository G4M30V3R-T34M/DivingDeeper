using FeTo.Singleton;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationPlayer : SingletonPersistent<ConversationPlayer>
{
    [SerializeField]
    TextMeshProUGUI speakerText, dialogueText;

    [SerializeField]
    Image psychologystPortrait, patientPortrait;

    [SerializeField]
    GameObject psychologistTalking, patientTalking;

    [SerializeField]
    GameObject continueObject;

    [SerializeField]
    float waitTimeBetweenLetters;

    ConversationScriptableObject currentConversation = null;
    int currentConversationPart = 0;
    QuestScriptableObject dialogueQuest = null;
    bool isConversationActive = false;
    bool isWriting = false;

    Coroutine currentCoroutine;

    private void Start()
    {
        CleanDialogue();
    }

    public void Play(ConversationScriptableObject conversation, QuestScriptableObject quest = null)
    {
        if (isConversationActive && dialogueQuest != null)
        {
            QuestManager.Instance.Complete(dialogueQuest.Id);
        }

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentConversation = conversation;
        currentConversationPart = 0;
        dialogueQuest = quest;
        isConversationActive = true;

        currentCoroutine = StartCoroutine(PlayConversationPart());
    }

    public void PlayerInteraction()
    {
        if (!isWriting && HasRemainingParts())
        {
            currentConversationPart++;
            currentCoroutine = StartCoroutine(PlayConversationPart());
        } else if (isWriting)
        {
            isWriting = false;
            continueObject.SetActive(true);
            StopCoroutine(currentCoroutine);
            dialogueText.text = currentConversation.conversationParts[currentConversationPart].text;
        } else
        {
            PerformConversationEndChecks();
            CleanDialogue();
        }
    }

    private void Activate(Actors actor)
    {
        Image image = (actor == Actors.Psychologyst) ? psychologystPortrait : patientPortrait;
        GameObject go = (actor == Actors.Psychologyst) ? psychologistTalking : patientTalking;

        Color color = image.color;
        color.a = 1f;
        image.color = color;

        go.SetActive(true);
    }

    private void Deactivate(Actors actor)
    {
        Image image = (actor == Actors.Psychologyst) ? psychologystPortrait : patientPortrait;
        GameObject go = (actor == Actors.Psychologyst) ? psychologistTalking : patientTalking;

        Color color = image.color;
        color.a = 0.5f;
        image.color = color;

        go.SetActive(false);
    }

    private IEnumerator PlayConversationPart()
    {
        isWriting = true;
        continueObject.SetActive(false);
        ConversationPartScriptableObject part = currentConversation.conversationParts[currentConversationPart];
        ActivateCurrentSpeaker();
        dialogueText.text = string.Empty;

        int i = 0;
        while (i < part.text.Length)
        {
            dialogueText.text += part.text[i++];
            yield return new WaitForSeconds(waitTimeBetweenLetters);
        }

        isWriting = false;
        continueObject.SetActive(true);
    }

    private void PerformConversationEndChecks()
    {
        if (currentConversationPart >= currentConversation.conversationParts.Count - 1)
        {
            isConversationActive = false;
            if (dialogueQuest != null)
            {
                QuestManager.Instance.Complete(dialogueQuest.Id);
                dialogueQuest = null;
            }
        }
    }

    private bool HasRemainingParts() =>
        currentConversationPart < currentConversation.conversationParts.Count - 1;

    private void ActivateCurrentSpeaker()
    {
        Actors actor = currentConversation.conversationParts[currentConversationPart].actor;
        speakerText.text = (actor == Actors.Psychologyst) ? "Psychologist" : "Patient";
        Activate(actor);
        Deactivate(actor == Actors.Psychologyst ? Actors.Patient : Actors.Psychologyst);
    }

    private void CleanDialogue()
    {
        Deactivate(Actors.Psychologyst);
        Deactivate(Actors.Patient);
        speakerText.text = string.Empty;
        dialogueText.text = string.Empty;
        continueObject.SetActive(false);
    }
}
