using UnityEngine;
using System.Collections;

public class NoTrigger : MonoBehaviour
{
    public InAppController controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.SendNo();
    }
}
