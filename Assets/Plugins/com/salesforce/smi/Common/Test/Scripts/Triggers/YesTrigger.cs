using UnityEngine;
using System.Collections;

public class YesTrigger : MonoBehaviour
{
    public InAppController controller;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Fired: Yes");
        controller.SendYes();
    }
}
