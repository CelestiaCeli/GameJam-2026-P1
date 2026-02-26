using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraModeChange : MonoBehaviour
{
    [SerializeField]
    private UnityEvent playerEnter;

    [SerializeField]
    private UnityEvent playerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerExit.Invoke();
        }
    }
}
