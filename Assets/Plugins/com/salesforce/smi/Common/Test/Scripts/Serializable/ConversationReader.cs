using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationReader : MonoBehaviour
{
    public TextAsset jsonFile;

    [HideInInspector]
    public Conversation conversation;

    // Start is called before the first frame update
    void Start()
    {
        conversation = JsonUtility.FromJson<Conversation>(jsonFile.text);
    }
}
