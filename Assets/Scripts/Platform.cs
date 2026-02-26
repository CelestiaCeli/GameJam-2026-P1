using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isBreakable;

    [SerializeField]
    bool isMoving;
    [SerializeField]
    bool movingLeft;

    void Update()
    {
        if (isMoving && movingLeft)
        {
            this.gameObject.transform.position -= new Vector3(3, 0, 0) * Time.deltaTime;
            if (this.gameObject.transform.position.x < -4 && movingLeft)
            {
                movingLeft = false;
            }
        }
        if (isMoving && !movingLeft)
        {
            this.gameObject.transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
            if (this.gameObject.transform.position.x > 6 && !movingLeft)
            {
                movingLeft = true;
            }
        }
    }
}
