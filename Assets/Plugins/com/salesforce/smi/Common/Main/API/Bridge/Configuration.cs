using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Plugins.Salesforce.InApp
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class Configuration : IEquatable<Configuration>
    {
        public string serviceURL;
        public string organizationId;
        public string developerName;

        public Configuration(string serviceURL, string organizationId, string developerName)
        {
            this.serviceURL = serviceURL;
            this.organizationId = organizationId;
            this.developerName = developerName;
        }

        public override bool Equals(Object obj)
        {
            var other = obj as Configuration;
            if (other == null) return false;

            return Equals(other);
        }

        public bool Equals(Configuration other)
        {
            if (other == null)
            {
                return false;
            }

            bool isEqual = true;

            isEqual = isEqual && ReferenceEquals(this, other);
            isEqual = isEqual && EqualityComparer<string>.Default.Equals(this.serviceURL, other.serviceURL);
            isEqual = isEqual && EqualityComparer<string>.Default.Equals(this.organizationId, other.organizationId);
            isEqual = isEqual && EqualityComparer<string>.Default.Equals(this.developerName, other.developerName);

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(serviceURL, organizationId, developerName);
        }
    }
}
