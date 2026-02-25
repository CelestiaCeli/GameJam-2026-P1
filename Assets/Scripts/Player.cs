using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge { get; private set; }
    public int playerHealth { get; private set; } = 100;

    const float chargeIncrease = 0.008f;
    const float chargeDecay = 0.005f;
    const int jumpStrength = 6;

    const float MAX_VELOCITY = 8;
    const float MIN_VELOCITY = -8;

    Rigidbody2D playerRB;
    Transform playerTransform;

    [SerializeField]
    ChargeMeter chargeMeter;
    [SerializeField]
    HealthMeter healthMeter;
    [SerializeField]
    BoxCollider2D groundCheck;

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
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.linearVelocityX -= 0.02f;
        }
        else if (!Input.GetKey(KeyCode.A) && playerRB.linearVelocityX < 0)
        {
            playerRB.linearVelocityX += 0.02f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRB.linearVelocityX += 0.02f;
        }
        else if (!Input.GetKey(KeyCode.D) && playerRB.linearVelocityX > 0)
        {
            playerRB.linearVelocityX -= 0.02f;
        }


        if (playerRB.linearVelocityX > MAX_VELOCITY)
        {
            playerRB.linearVelocityX = MAX_VELOCITY;
        }
        if (playerRB.linearVelocityX < MIN_VELOCITY)
        {
            playerRB.linearVelocityX = MIN_VELOCITY;
        }

        if (Input.GetKey(KeyCode.W))
        {
            jumpCharge += chargeIncrease;
            if (jumpCharge > 3)
            { jumpCharge = 3; }
        }
        else
        {
            jumpCharge -= chargeDecay;
            if (jumpCharge < 0)
            {  jumpCharge = 0; }
        }
        chargeMeter.UpdateChargeMeter(jumpCharge);
    }

    public void PlayerJump()
    {
        playerRB.linearVelocityY = jumpStrength + (jumpCharge * 2);
        jumpCharge = 0;
    }

    public float GetPlayerVelocity()
    {
        return playerRB.linearVelocityY;
    }

    public void SetPlayerVelocity(float value)
    {
        playerRB.linearVelocityY = value;
    }
}
