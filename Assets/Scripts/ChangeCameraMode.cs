using System;
using UnityEngine;
using UnityEngine.Events;

public class ChangeCameraMode : MonoBehaviour
{
    private UnityEvent playerBarrier;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerBarrier.Invoke();
        }
    }
}
