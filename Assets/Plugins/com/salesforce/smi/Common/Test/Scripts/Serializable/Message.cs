using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{
    [System.Serializable]
    public class Content
    {
        public string message;
    }

    [System.Serializable]
    public class Date
    {
        public string days;
        public string minutes;
    }

    public Content content;
    public Date date;
    public string origin;
    public string status;
    public string type;
}
