using System;
using UnityEngine;

public class MovablePlatform : Platform
{
    [SerializeField]
    bool isMoving;
    [SerializeField]
    private float speed;
    private float offSet = 0.1f;
    private float overallTime;
    [SerializeField] private bool loggable = false;
    private bool moveToTarget;
    public Vector2 targetPos;

    void Start()
    {
        moveToTarget = true;
        originPoint = gameObject.transform.localPosition;
    }

    private void MoveToTarget()
    {
        float difference = Vector2.Distance(transform.localPosition, targetPos);
        if (loggable)
        {
            Debug.Log(difference);
            Debug.Log(originPoint);
            Debug.Log(targetPos);
        }

        overallTime += Time.deltaTime * speed;
        if(difference > offSet)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, targetPos, overallTime);
        }
        else
        {
            overallTime = 0;
            moveToTarget = false;
        }
    }

    private void MoveToOrigin()
    {
        float difference = Vector2.Distance(transform.localPosition, originPoint);
        
        overallTime += Time.deltaTime * speed;
        if(difference > offSet)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originPoint, overallTime);
        }
        else
        {
            overallTime = 0;
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
