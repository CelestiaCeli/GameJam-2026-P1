using UnityEngine;

public class Ibuprofen : Item
{
    private const int HP_RESTORED = 3;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.Heal(HP_RESTORED);
        }

        Destroy(gameObject);
    }
}
