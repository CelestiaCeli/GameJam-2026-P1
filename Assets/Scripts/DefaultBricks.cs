using UnityEngine;

public class DefaultBricks : MonoBehaviour
{
    const int HP_DAMAGED = -3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.ModifyHP(HP_DAMAGED);
        }
    }
}