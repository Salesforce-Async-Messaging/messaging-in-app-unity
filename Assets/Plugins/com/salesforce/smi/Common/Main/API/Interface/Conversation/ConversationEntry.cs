using System;

namespace Plugins.Salesforce.InApp
{
    [Serializable]
    public class ConversationEntry<P> where P: Payload
    {
        public string conversationId;
        public string id;
        public ulong timestamp;
        public string format;
        public string type;
        public string status;
        public P payload;
        public Participant sender;
    }
}