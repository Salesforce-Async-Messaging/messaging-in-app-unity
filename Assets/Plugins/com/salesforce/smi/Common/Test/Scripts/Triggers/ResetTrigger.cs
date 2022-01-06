using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public InAppController controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.Reset();
    }
}