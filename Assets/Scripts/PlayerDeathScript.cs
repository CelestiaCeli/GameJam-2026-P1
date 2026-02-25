using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField]
    GameObject deathScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
