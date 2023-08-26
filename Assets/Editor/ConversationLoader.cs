#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ConversationLoader
{
    private const int CODE = 0;


    [MenuItem("DivingDeeper/LoadConversations")]
    static void LoadConversations()
    {
        string path = $"{UnityEngine.Application.dataPath}/Editor/CSV/conversations.csv";

        string[] lines = LoadCsvData(path);
        Dictionary<string, ConversationScriptableObject> previousConversations = GetCurrentConversations();
        RemoveOldConversationParts();

        foreach (string line in lines)
        {
            LoadConversation(line, previousConversations);
        }

        RemoveRemainingPreviousConversations(previousConversations);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    static string[] LoadCsvData(string path)
    {
        TextAsset asset = Resources.Load<TextAsset>("CSV/Conversations");
        string[] lines = asset.text.Split('\n');
        lines = lines.Skip(1).Take(lines.Length - 1).ToArray();

        return lines;
    }

    static void RemoveOldConversationParts()
    {
        List<string> failedPaths = new();
        AssetDatabase.DeleteAssets(new string[] { "Assets/Resources/Conversations/Parts" }, failedPaths);
    }

    static Dictionary<string, ConversationScriptableObject> GetCurrentConversations()
    {
        Dictionary<string, ConversationScriptableObject> conversationsDict = new();
        ConversationScriptableObject[] conversations = Resources.LoadAll<ConversationScriptableObject>("Conversations");

        foreach (var conversation in conversations)
        {
            conversation.conversationParts.Clear();
            conversationsDict.Add(conversation.name, conversation);
        }

        return conversationsDict;
    }

    static void LoadConversation(string line, Dictionary<string, ConversationScriptableObject> previousConversations)
    {
        List<string> parsedLine = ParseLine(line);

        if (previousConversations.TryGetValue(parsedLine[CODE], out ConversationScriptableObject conversation))
        {
            UpdateConversation(parsedLine, conversation);
            EditorUtility.SetDirty(conversation);
            previousConversations.Remove(parsedLine[CODE]);
        } else
        {
            CreateNewConversation(parsedLine);
        }
    }

    static List<string> ParseLine(string line)
    {
        List<string> parsedValues = new();

        StringBuilder currentPart = new StringBuilder();
        bool insideQuotes = false;

        foreach (char c in line)
        {
            if (c.Equals(',') && !insideQuotes)
            {
                parsedValues.Add(currentPart.ToString());
                currentPart = new StringBuilder();
            } else if (c.Equals('"'))
            {
                insideQuotes = !insideQuotes;
            } else
            {
                currentPart.Append(c);
            }
        }

        return parsedValues;
    }

    static void UpdateConversation(List<string> parsedLine, ConversationScriptableObject conversation)
    {
        List<ConversationPartScriptableObject> conversationParts = CreateConversationParts(parsedLine);
        conversation.conversationParts = conversationParts;
    }

    static void CreateNewConversation(List<string> parsedLine)
    {
        string code = parsedLine[CODE];
        List<ConversationPartScriptableObject> conversationParts = CreateConversationParts(parsedLine);

        ConversationScriptableObject conversation = ScriptableObject.CreateInstance<ConversationScriptableObject>();
        conversation.conversationParts = conversationParts;
        AssetDatabase.CreateAsset(conversation, $"Assets/Resources/Conversations/{code}.asset");
    }

    static List<ConversationPartScriptableObject> CreateConversationParts(List<string> parsedLine)
    {
        List<ConversationPartScriptableObject> conversationParts = new();

        string path = "Assets/Resources/Conversations/Parts";

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Resources/Conversations", "Parts");
        }

        // The first one (0) is the code
        for (int i = 1; i < parsedLine.Count; i++)
        {
            if (parsedLine[i].Contains("#"))
            {
                string[] splits = parsedLine[i].Split('#');
                Actors actor = GetActorFromCode(splits[0]);
                string text = splits[1];

                ConversationPartScriptableObject conversationPart = ScriptableObject.CreateInstance<ConversationPartScriptableObject>();
                conversationPart.actor = actor;
                conversationPart.text = text;
                AssetDatabase.CreateAsset(conversationPart, $"Assets/Resources/Conversations/Parts/{parsedLine[0]}_{i}.asset");
                conversationParts.Add(conversationPart);
            }
        }

        return conversationParts;
    }

    static Actors GetActorFromCode(string code)
    {
        return code == "P" ? Actors.Psychologyst : Actors.Patient;
    }

    static void RemoveRemainingPreviousConversations(Dictionary<string, ConversationScriptableObject> previousConversations)
    {
        foreach (var conversation in previousConversations)
        {
            AssetDatabase.DeleteAsset($"Assets/Resources/Conversations/{conversation.Key}");
        }
    }
}
#endif
