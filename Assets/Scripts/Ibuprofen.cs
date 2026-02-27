using UnityEngine;
using System.Collections;

public class Ibuprofen : Item
{
    private const int HP_RESTORED = 20;

    public bool animDone { get; set; } = false;
    [SerializeField] private Animation ibuprofenCollect;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.ModifyHP(HP_RESTORED);
            }

            StartCoroutine(IbuprofenParticle());
        }

    }

    private IEnumerator IbuprofenParticle()
    {
        ibuprofenCollect.Play();
        yield return new WaitUntil(() => animDone);
        Destroy(gameObject);
    }
}
