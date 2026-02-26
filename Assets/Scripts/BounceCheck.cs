using UnityEngine;

public class BounceCheck : MonoBehaviour
{
    Player player;

    private const int BrickBrainDamage = -5;

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            if (player.GetPlayerVelocity() < 0)
            {
                player.collided = false;
                player.PlayerJump();

                if (other.gameObject.GetComponent<Platform>().isBreakable)
                {
                    Destroy(other.gameObject);
                }
            }
        }
        else if (other.gameObject.tag == "Brick")
        {
            if (player.chargeAmount > 0)
            {
                player.ModifyHP(BrickBrainDamage);
                Destroy(other.gameObject);
                player.chargeAmount--;
                player.collided = true;
            }
            else 
            {
                player.SetPlayerVelocity(0);
            }

            if (player.GetPlayerVelocity() < 0)
            {
                player.PlayerJump();
            }
        }
        else if (other.gameObject.tag == "Checkpoint")
        {
            return;
        }
    }
}
