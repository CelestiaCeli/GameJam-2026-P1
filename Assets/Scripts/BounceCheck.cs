using UnityEngine;

public class BounceCheck : MonoBehaviour
{
    Player player;

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
                player.PlayerJump();

                if (other.gameObject.GetComponent<Platform>().isBreakable)
                {
                    Destroy(other.gameObject);
                }
            }
        }
        else if (other.gameObject.tag == "Brick")
        {
            if (player.GetPlayerVelocity() > 5)
            {
                Destroy(other.gameObject);
                player.SetPlayerVelocity(0);
            }
            else if (player.GetPlayerVelocity() > 0)
            {
                player.SetPlayerVelocity(0);
            }

            if (player.GetPlayerVelocity() < 0)
            {
                player.PlayerJump();
            }
        }
        else
        {
            player.PlayerJump();
        }
    }
}
