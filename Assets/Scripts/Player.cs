using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge;
    public int playerHealth;
    
    Rigidbody2D playerRB;
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    public void Heal()
    {

    }

    public void TakeDamage()
    {

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
