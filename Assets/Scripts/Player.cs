using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge { get; private set; }
    public int playerHealth { get; private set; } = 100;
    
    Rigidbody2D playerRB;
    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    public void Heal(int healthRestored)
    {
        if(playerHealth < 100)
        {
            playerHealth += healthRestored;
            if(playerHealth > 100)
            {
                playerHealth = 100;
            }
        }
    }

    public void TakeDamage(int healthDamaged)
    {
        playerHealth -= healthDamaged;
        if(playerHealth < 0)
        {
            playerHealth = 0;
        }
    }

    void CheckInput()
    {
        /*if (Input.GetKey(KeyCode.A))
        {
            player.position -= new Vector3(-4, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.position -= new Vector3(4, 0, 0);
        }*/
    }
}
