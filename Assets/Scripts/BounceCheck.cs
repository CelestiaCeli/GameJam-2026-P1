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
        else
        {
            player.PlayerJump();
        }
    }
}
