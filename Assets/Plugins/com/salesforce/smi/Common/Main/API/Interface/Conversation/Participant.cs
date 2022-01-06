using System;

namespace Plugins.Salesforce.InApp
{
    [Serializable]
    public class Participant
    {
        public string subject;
        public string role;
        public string displayName;
        public bool local;
    }
}