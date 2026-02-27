using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge { get; private set; }
    [field:SerializeField]
    public int playerHealth { get; private set; } = 100;

    const float CHARGE_INCREASE = 3f;
    const float CHARGE_DECAY = 2f;
    const int JUMP_STRENGTH = 6;

    const float MAX_VELOCITY = 8f;
    const float MIN_VELOCITY = -8f;
    const float SPEED = 12f;
    public bool frozen;
    public bool collided = false;

    public int chargeAmount;

    Rigidbody2D playerRB;
    public Transform playerTransform;
    Vector2 playerVelocityBuffer;

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

    public void ModifyHP(int health)
    {
        if (playerHealth + health > 0 && playerHealth + health < 100) { playerHealth += health; }

        Debug.Log(playerHealth);
        healthMeter.UpdateHealthMeter(playerHealth);
    }

    public void FreezePlayer()
    {
        playerVelocityBuffer = playerRB.linearVelocity;
        playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnfreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerRB.linearVelocityX = playerVelocityBuffer.x;
        playerRB.linearVelocityY = -playerVelocityBuffer.y;
    }
    
    void CheckInput()
    {
        if (frozen)
        {
            return;
        }
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

        if (Input.GetKey(KeyCode.W) && !collided)
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
