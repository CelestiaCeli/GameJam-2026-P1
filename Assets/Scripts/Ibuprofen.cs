using UnityEngine;

public class Ibuprofen : Item
{
    private const int HP_RESTORED = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.Heal(HP_RESTORED);
        }

        OnHit();
    }
}
