using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public bool Stationary;

    [SerializeField] private GameObject player;
    [SerializeField] private float DEATHOFFSET;
    private Vector3 playerDeathPos = new Vector3(0, 0, 0);
    public bool paused { get; set; }
    
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

    void Update()
    {
        if (player.transform.position.y - DEATHOFFSET > this.gameObject.transform.position.y && !paused)
        {
            playerDeathPos = new Vector3(0, player.transform.position.y - DEATHOFFSET, 0);
            gameObject.transform.position = playerDeathPos;
        }
    }
}
