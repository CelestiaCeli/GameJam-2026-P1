using System;
using UnityEngine;

public class MovablePlatform : Platform
{
    [SerializeField]
    bool isMoving;
    [SerializeField]
    private float speed;
    private float offSet = 0.1f;
    private bool moveToTarget;
    public Vector2 targetPos;

    void Start()
    {
        moveToTarget = true;
        originPoint = this.gameObject.transform.position;
        targetPos.y = originPoint.y;
    }

    private void MoveToTarget()
    {
        float difference = Vector2.Distance(this.transform.position, targetPos);
        if(difference > offSet)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, targetPos, speed * Time.deltaTime);
        }
        else
        {
            moveToTarget = false;
        }
    }

    private void MoveToOrigin()
    {
        float difference = Vector2.Distance(this.transform.position, originPoint);
        if(difference > offSet)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, originPoint, speed * Time.deltaTime);
        }
        else
        {
            moveToTarget = true;
        }
    }

    void Update()
    {
        if(isMoving)
        {
            if(moveToTarget)
            {
                MoveToTarget();
            }
            else
            {
                MoveToOrigin();
            }
        }
    }
}
