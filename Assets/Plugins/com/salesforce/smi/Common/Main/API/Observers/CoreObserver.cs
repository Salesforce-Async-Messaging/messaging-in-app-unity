namespace Plugins.Salesforce.InApp
{
    public interface CoreObserver
    {
        public void ReceiveEntry(Core core, ConversationEntry<Payload> entry);
        public void UpdateEntry(Core core, ConversationEntry<Payload> entry);
        public void ReceiveTypingStartedEvent(Core core, ConversationEntry<Payload> entry);
        public void ReceiveTypingStoppedEvent(Core core, ConversationEntry<Payload> entry);
        public void ChangeNetworkStatus(string status);
        public void UpdateConversationHighWaterMarks(Core core, Conversation conversation);
        public void Error(Core core, string error);
    }
}