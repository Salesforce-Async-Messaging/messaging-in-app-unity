using System;

namespace Plugins.Salesforce.InApp
{
    [Serializable]
    public class TextMessage: Payload
    {
        public string text;
    }
}
