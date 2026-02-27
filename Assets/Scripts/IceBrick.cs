using UnityEngine;
using System.Collections;

public class IceBrick : DefaultBricks
{
    const float TIME_FROZEN = 2.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(FreezeCoroutine(player));
        }
    }

    public IEnumerator FreezeCoroutine(Player player)
    {
        player.FreezePlayer();
        Destroy(gameObject, TIME_FROZEN + 0.1f);
        yield return new WaitForSeconds(TIME_FROZEN);
        player.UnfreezePlayer();
    }
}
