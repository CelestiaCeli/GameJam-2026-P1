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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Platform platformHit = other.gameObject.GetComponent<Platform>();
            Rigidbody2D platformRB = platformHit.GetComponent<Rigidbody2D>();
            if (platformHit.movingVertical)
            {
                player.SetPlayerVelocity(platformRB.linearVelocityY + player.GetPlayerVelocity());
            }
            else
            {
                player.SetPlayerVelocityX(platformRB.linearVelocityX);
            }
        }
    }
}
