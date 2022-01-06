using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Plugins.Salesforce.InApp.Android
{
    internal sealed class Core : AndroidJavaProxy, InApp.Core
    {
        const string unityPlayerName = "com.unity3d.player.UnityPlayer";
        const string pluginName = "com.salesforce.messaginginappwrapper.UnityWrapper";
        const string pluginCallBackName = "com.salesforce.messaginginappwrapper.UnityInterface";
        const string pluginConfigName = "com.salesforce.android.smi.core.CoreConfiguration";

        private static readonly Lazy<Core> lazy = new Lazy<Core>(() => new Core());
        private readonly AndroidJavaClass androidInterface = new AndroidJavaClass(pluginName);

        public static Core Instance {
            get
            {
                return lazy.Value;
            }
        }

        private Configuration _config = null;
        public Configuration config {
            get
            {
                return _config;
            }

            set
            {
                if (_config == value)
                {
                    return;
                }


                _config = value;

                AndroidJavaClass unityPlayer = new AndroidJavaClass(unityPlayerName);
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");
                AndroidJavaObject url = new AndroidJavaObject("java.net.URL", _config.serviceURL);
                AndroidJavaObject androidConfig = new AndroidJavaObject(pluginConfigName, url, _config.organizationId, _config.developerName);
                androidInterface.CallStatic("registerConfig", context, androidConfig, this);
            }
        }

        private List<CoreObserver> observers;

        private Core() : base(pluginCallBackName)
        {
            observers = new List<CoreObserver>();
        }

        ~Core()
        {
        }

        public string status
        {
            get { return "placeholder"; }
        }

        public void Attach(CoreObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(CoreObserver observer)
        {
            observers.Remove(observer);
        }

        public Task RetrieveRemoteConfiguration()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            androidInterface.CallStatic("start");
        }

        public void Stop()
        {
            androidInterface.CallStatic("stop");
        }

        public void Reset()
        {
            androidInterface.CallStatic("reset");
        }

        ConversationClient InApp.Core.conversationClient(string id)
        {
            return new ConversationClient(id, this);
        }

        void InApp.Core.SendMessage(string message, ConversationClient client)
        {
            Debug.Log("C#: Core [SendMessage]");
            androidInterface.CallStatic("sendMessage", message, client.id);
        }

        private void HandleDidReceiveEntry(ConversationEntry<Payload> entry)
        {
            Debug.Log("C#: Core [HandleDidReceiveEntry]");
            foreach (CoreObserver observer in observers)
            {
                observer.ReceiveEntry(this, entry);
            }
        }

        void onMessageReceived(AndroidJavaObject result)
        {
            var entry = new ConversationEntry<Payload>();
            Debug.Log("C#: Native Message Received: " + result.Call<string>("toString"));

            var androidEntry = result.Get<AndroidJavaObject>("conversationEntry");
            var participant = extractParticipantFromEvent(androidEntry);
            var payload = extractPayloadFromEvent(androidEntry);
            var conversationId = androidEntry.Get<AndroidJavaObject>("conversationId");

            entry.sender = participant;
            entry.payload = payload;
            entry.conversationId = conversationId.Call<string>("toString");
            entry.status = "placeholder"; // Fill this in with proper status type.
            entry.id = androidEntry.Get<string>("identifier");
            entry.timestamp = androidEntry.Get<ulong>("timestamp");
            entry.format = "Text"; // Fill this in with proper format.
            entry.type = "Message"; // Fill this in with proper type.

            HandleDidReceiveEntry(entry);
        }

        private Participant extractParticipantFromEvent(AndroidJavaObject result)
        {
            var participant = new Participant();
            var androidParticipant = result.Get<AndroidJavaObject>("sender");
            participant.displayName = result.Get<string>("senderDisplayName");
            participant.local = androidParticipant.Get<bool>("isLocal");
            participant.role = androidParticipant.Get<string>("app");
            participant.subject = androidParticipant.Get<string>("subject");

            return participant;
        }

        private Payload extractPayloadFromEvent(AndroidJavaObject result)
        {
            var payload = new TextMessage();

            var androidPayload = result.Get<AndroidJavaObject>("payload");
            var androidContent = androidPayload.Get<AndroidJavaObject>("content");

            payload.text = androidContent.Get<string>("text");

            return payload;
        }
    }
}