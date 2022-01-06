using UnityEngine;
using System.Collections;

public class NewTrigger : MonoBehaviour
{
    public InAppController controller;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Fired: New");
        controller.New();
    }
}
