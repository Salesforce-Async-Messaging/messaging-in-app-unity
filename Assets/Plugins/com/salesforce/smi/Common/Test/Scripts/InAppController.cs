using System;
using System.Collections.Generic;
using Plugins.Salesforce.InApp;
using UnityEngine;
using UnityEngine.UI;

public class InAppController : MonoBehaviour, ConversationClientObserver
{
    public Text display;
    List<string> dataSource = new List<string>();

    private Core core;
    private ConversationClient client;
    public Configuration config;
    public string conversationId;

    // Start is called before the first frame update
    void Awake()
    {
        if (string.IsNullOrEmpty(conversationId))
        {
            conversationId = Guid.NewGuid().ToString();
        }
         
        core = CoreFactory.ReturnCore(config);
        client = core.conversationClient(conversationId);
        client.Attach(this);

        core.Start();
    }
   
    void Update()
    {
        display.text = string.Join("\n", dataSource.ToArray());
    }

    public void Reset()
    {
        Debug.Log("Received Trigger: Reset");
        dataSource.Clear();
    }

    public void New()
    {
        Debug.Log("Received Trigger: New");

        Reset();
        conversationId = Guid.NewGuid().ToString();
        client = core.conversationClient(conversationId);
        client.Attach(this);
        client.SendMessage("New Conversation: " + conversationId);

    }

    public void SendYes()
    {
        Debug.Log("Received Trigger: Yes");
        client.SendMessage("Yes");
    }

    public void SendNo()
    {
        Debug.Log("Received Trigger: No");
        client.SendMessage("No");
    }

    public void UpdateEntry(ConversationClient client, ConversationEntry<Payload> entry)
    {
        throw new NotImplementedException();
    }

    public void ReceiveTypingStartedEvent(ConversationClient client, ConversationEntry<Payload> entry)
    {
        throw new NotImplementedException();
    }

    public void ReceiveTypingStoppedEvent(ConversationClient client, ConversationEntry<Payload> entry)
    {
        throw new NotImplementedException();
    }

    public void UpdateConversationHighWaterMarks(ConversationClient client)
    {
        throw new NotImplementedException();
    }

    public void CreateConversation(ConversationClient client, Plugins.Salesforce.InApp.Conversation conversation)
    {
        throw new NotImplementedException();
    }

    public void Error(ConversationClient client, string message)
    {
        throw new NotImplementedException();
    }

    public void ReceiveEntry(ConversationClient client, ConversationEntry<Payload> entry)
    {
        Debug.Log("C#: InAppController [ReceiveEntry]");

        Payload payload = entry.payload;
        if (payload.GetType() == typeof(TextMessage))
        {
            Debug.Log("C#: InAppController Resolved Type");
            TextMessage message = (TextMessage)payload;
            string displayName = entry.sender.local ? "ME" : entry.sender.displayName;
            string line = displayName + "> " + message.text + "\n";

            Debug.Log("C#: InAppController Line: " + line);
            dataSource.Add(line);
        }

    }
}
