using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public bool Stationary;

    [SerializeField] private GameObject player;
    
    [SerializeField]
    GameObject deathScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
