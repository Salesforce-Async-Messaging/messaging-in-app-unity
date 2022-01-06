using System.Threading.Tasks;

namespace Plugins.Salesforce.InApp
{
    public interface Core
    {
        public static Core Instance { get; }

        public Configuration config { get; }
        public string status { get; }

        public ConversationClient conversationClient(string id);

        public Task RetrieveRemoteConfiguration();

        public void Start();
        public void Stop();
        public void Reset(); // XXX This should be async

        public void Attach(CoreObserver observer);
        public void Detach(CoreObserver observer);

        internal void SendMessage(string message, ConversationClient client);
    }
}
    