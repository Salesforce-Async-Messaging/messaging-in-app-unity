namespace Plugins.Salesforce.InApp
{
    public interface ConversationClientObserver
    {
        public void ReceiveEntry(ConversationClient client, ConversationEntry<Payload> entry);
        public void UpdateEntry(ConversationClient client, ConversationEntry<Payload> entry);
        public void ReceiveTypingStartedEvent(ConversationClient client, ConversationEntry<Payload> entry);
        public void ReceiveTypingStoppedEvent(ConversationClient client, ConversationEntry<Payload> entry);
        public void UpdateConversationHighWaterMarks(ConversationClient client);
        public void CreateConversation(ConversationClient client, Conversation conversation);
        public void Error(ConversationClient client, string message);
    }
}
