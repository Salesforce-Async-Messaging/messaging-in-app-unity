using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;
using Newtonsoft.Json;
using UnityEngine;

namespace Plugins.Salesforce.InApp.iOS
{
    internal sealed class Core : InApp.Core
    {
#if UNITY_IOS
        private const string import = "__Internal";

        [DllImport(import)] private static extern bool IAW_Core_RegisterConfig(Configuration inConfig);

        [DllImport(import)] private static extern bool IAW_Core_Start();
        [DllImport(import)] private static extern bool IAW_Core_Stop();
        [DllImport(import)] private static extern bool IAW_Core_Reset();
        [DllImport(import)] private static extern bool IAW_Core_SendMessage(string inMessage, string inConversationId);


        private delegate void DidReceiveEntryDelegate(string entry);
        [DllImport(import)] private static extern void IAW_Core_Delegate_RegisterDidReceiveMessage(DidReceiveEntryDelegate callback);
        [MonoPInvokeCallback(typeof(DidReceiveEntryDelegate))]
        private static void Marshalled_DidReceiveEntry(string json)
        {
            Debug.Log("[InApp]: Core [HandleDidReceiveEntry] \n" + json);
            ConversationEntry<Payload> entry = JsonConvert.DeserializeObject<ConversationEntry<Payload>>(json, new ConversationEntryConverter());
            Core.Instance.HandleDidReceiveEntry(entry);
        }
#endif

        private static readonly Lazy<Core> lazy = new Lazy<Core>(() => new Core());
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
#if UNITY_IOS
                IAW_Core_RegisterConfig(this.config);
#endif
            }
        }

        private List<CoreObserver> observers;

        private Core()
        {
            observers = new List<CoreObserver>();

#if UNITY_IOS
            IAW_Core_Delegate_RegisterDidReceiveMessage(Marshalled_DidReceiveEntry);
#endif
        }

        ~Core()
        {
#if UNITY_IOS
            IAW_Core_Delegate_RegisterDidReceiveMessage(null);
#endif
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
#if UNITY_IOS
            IAW_Core_Start();
#endif
        }

        public void Stop()
        {
#if UNITY_IOS
            IAW_Core_Stop();
#endif
        }

        public void Reset()
        {
#if UNITY_IOS
            IAW_Core_Reset();
#endif
        }

        ConversationClient InApp.Core.conversationClient(string id)
        {
            return new ConversationClient(id, this);
        }

        void InApp.Core.SendMessage(string message, ConversationClient client)
        {
#if UNITY_IOS
            IAW_Core_SendMessage(message, client.id);
#endif
        }

        private void HandleDidReceiveEntry(ConversationEntry<Payload> entry)
        {
            Debug.Log("[InApp]: Core [HandleDidReceiveEntry]");
            foreach (CoreObserver observer in observers)
            {
                observer.ReceiveEntry(this, entry);
            }
        }
    }
}