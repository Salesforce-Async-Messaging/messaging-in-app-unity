using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Plugins.Salesforce.InApp
{
    public class ConversationClient: CoreObserver
    {
        private WeakReference _core;
        public string id { get; private set; }

        private List<ConversationClientObserver> observers;

        internal ConversationClient(string id, Core core)
        {
            this.id = id;
            _core = new WeakReference(core);

            observers = new List<ConversationClientObserver>();
            core.Attach(this);
        }

        public InApp.Core core
        {
            get { return _core.Target as Core; }
        }

        public void Attach(ConversationClientObserver observer)
        {
            Debug.Log("[InApp] ConversationClient [Attach]");
            Debug.Log("[InApp] Observer: " + observer);
            observers.Add(observer);
        }

        public void Detatch(ConversationClientObserver observer)
        {
            observers.Remove(observer);
        }

        public Task Entries()
        {
            throw new NotImplementedException();
        }

        public Task Entries(uint limit, uint offset)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            Core sCore = this.core;
            if (sCore == null) { return; }

            sCore.SendMessage(message, this);
        }

        public void SendReply()
        {
            throw new NotImplementedException();
        }

        public void SendTypingEvent()
        {
            throw new NotImplementedException();
        }

        public void SubmitPreChatFields()
        {
            throw new NotImplementedException();
        }

        public void ReceiveEntry(Core core, ConversationEntry<Payload> entry)
        {
            Debug.Log("[InApp] ConversationClient [ReceiveEntry]");
            Debug.Log("[InApp] Conversation Id: " + entry.conversationId);
            Debug.Log("[InApp] Client Conversation Id: " + id);
            Debug.Log("[InApp] Observers: " + observers);

            if (entry.conversationId.ToUpper() == id.ToUpper())
            {
                Debug.Log("[InApp] Conversation ID Match");
                foreach (ConversationClientObserver observer in observers)
                {
                    observer.ReceiveEntry(this, entry);
                }
            }
        }

        public void UpdateEntry(Core core, ConversationEntry<Payload> entry)
        {
            throw new NotImplementedException();
        }

        public void ReceiveTypingStartedEvent(Core core, ConversationEntry<Payload> entry)
        {
            throw new NotImplementedException();
        }

        public void ReceiveTypingStoppedEvent(Core core, ConversationEntry<Payload> entry)
        {
            throw new NotImplementedException();
        }

        public void ChangeNetworkStatus(string status)
        {
            throw new NotImplementedException();
        }

        public void UpdateConversationHighWaterMarks(Core core, Conversation conversation)
        {
            throw new NotImplementedException();
        }

        public void Error(Core core, string error)
        {
            throw new NotImplementedException();
        }
    }
}