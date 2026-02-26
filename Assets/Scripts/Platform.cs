using System;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isBreakable;
    public bool movingVertical;

    [SerializeField]
    bool isMoving;
    [SerializeField]
    float speed;
    [SerializeField]
    float moveDistance;

    private Vector3 originPoint;
    private Rigidbody2D platformRB;

    void Start()
    {
        platformRB = gameObject.GetComponent<Rigidbody2D>();
        if (movingVertical)
        {
            platformRB.linearVelocity = new Vector2(0, speed);
            platformRB.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            platformRB.linearVelocity = new Vector2(speed, 0);
            platformRB.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }

        originPoint = this.transform.position;
    }

    private void MovePlatform()
    {
        if(movingVertical)
        {
            float distanceY = this.transform.position.y - originPoint.y;
            if (distanceY >= moveDistance || distanceY <= -moveDistance)
            {
                platformRB.linearVelocityY = -platformRB.linearVelocityY;
            }
        }
        else
        {
            float distanceX = this.transform.position.x - originPoint.x;
            if (distanceX >= moveDistance || distanceX <= -moveDistance)
            {
                platformRB.linearVelocityX = -platformRB.linearVelocityX;
            }
        }
    }

    void Update()
    {
        if(isMoving)
        {
            MovePlatform();
        }
    }
}
