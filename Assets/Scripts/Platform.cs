using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isBreakable;

    [SerializeField]
    bool isMoving;
    [SerializeField]
    bool movingLeft;

    private Vector3 originPoint;
    [field: SerializeField] private Vector3 moveLeftAmount = new Vector3(-3,0,0); 
    [field: SerializeField] private Vector3 moveRightAmount = new Vector3(6,0,0);

    [field: SerializeField] public float Speed;
    private float timevar = 0;
    
    void Update()
    {
        timevar += Time.deltaTime;
        if (isMoving && movingLeft)
        {
            this.gameObject.transform.position = Vector2.Lerp(originPoint, moveLeftAmount, timevar * Speed);
            this.gameObject.transform.position -= new Vector3(3, 0, 0) * Time.deltaTime;
            if (this.gameObject.transform.position == moveLeftAmount && movingLeft)
            {
                originPoint =  this.gameObject.transform.position;
                movingLeft = false;
            }
        }
        if (isMoving && !movingLeft)
        {
            this.gameObject.transform.position = Vector2.Lerp(originPoint, moveRightAmount, timevar * Speed);
            if (this.gameObject.transform.position == moveRightAmount && !movingLeft)
            {
                originPoint = this.gameObject.transform.position;
                movingLeft = true;
            }
        }
    }

    private void Start()
    {
        originPoint = this.gameObject.transform.position;
    }
}
