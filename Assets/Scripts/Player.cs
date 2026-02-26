using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge { get; private set; }
    public int playerHealth { get; private set; } = 100;

    const float CHARGE_INCREASE = 3f;
    const float CHARGE_DECAY = 2f;
    const int JUMP_STRENGTH = 6;

    const float MAX_VELOCITY = 8f;
    const float MIN_VELOCITY = -8f;
    const float SPEED = 12f;

    public int chargeAmount;

    Rigidbody2D playerRB;
    public Transform playerTransform;

    public float playerHeight { get; private set; } = 0;

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
        playerHeight = gameObject.transform.position.y;
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
            playerRB.linearVelocityX -= SPEED * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.A) && playerRB.linearVelocityX < 0)
        {
            playerRB.linearVelocityX += SPEED * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRB.linearVelocityX += SPEED * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.D) && playerRB.linearVelocityX > 0)
        {
            playerRB.linearVelocityX -= SPEED * Time.deltaTime;
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
            jumpCharge += CHARGE_INCREASE * Time.deltaTime;
            if (jumpCharge > 3)
            { jumpCharge = 3; }

            chargeAmount = (int)jumpCharge;
        }
        else
        {
            jumpCharge -= CHARGE_DECAY * Time.deltaTime;
            if (jumpCharge < 0)
            {  jumpCharge = 0; }
        }
        chargeMeter.UpdateChargeMeter(jumpCharge);
    }

    public void PlayerJump()
    {
        playerRB.linearVelocityY = JUMP_STRENGTH + (jumpCharge * 2);
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
