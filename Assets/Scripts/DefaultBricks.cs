using System.Collections.Generic;
using UnityEngine;

public class DefaultBricks : MonoBehaviour
{
    const int HP_DAMAGED = -3;
    
    [field: SerializeField]
    public List<Sprite> sprites { get; private set; } = new List<Sprite>();

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.ModifyHP(HP_DAMAGED);
        }
    }
}