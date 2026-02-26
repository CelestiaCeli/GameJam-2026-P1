using UnityEngine;

public class FireBricks : DefaultBricks
{
    const int HP_DAMAGED = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(HP_DAMAGED);
        }
    }
}