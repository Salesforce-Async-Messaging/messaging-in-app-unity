using System;
using UnityEngine;

namespace Plugins.Salesforce.InApp
{
    public static class CoreFactory
    {
        public static Core ReturnCore(Configuration config)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    iOS.Core ios = iOS.Core.Instance;
                    ios.config = config;
                    return ios;

                case RuntimePlatform.Android:
                    Android.Core android = Android.Core.Instance;
                    android.config = config;
                    return android;

                default:
                    throw new PlatformNotSupportedException();
            }
        }
    }
}