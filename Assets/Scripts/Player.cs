using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpCharge { get; private set; }
    public int playerHealth { get; private set; } = 100;

    const float chargeIncrease = 0.008f;
    const float chargeDecay = 0.005f;

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
            playerTransform.position += new Vector3(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position += new Vector3(0.01f, 0, 0);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerRB.linearVelocityY = 5 + (Mathf.Round(jumpCharge) * 2) + 1;
        jumpCharge = 0;
    }
}
