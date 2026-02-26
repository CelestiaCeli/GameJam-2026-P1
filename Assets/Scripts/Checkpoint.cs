using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    GameObject[] Bricks;
    [SerializeField]
    CameraFollow mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (!CheckBricks())
        {
            mainCamera.isFollowingPlayer = true;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        mainCamera.isFollowingPlayer = false;
    }

    bool CheckBricks()
    {
        for (int i = 0;  i < Bricks.Length; i++)
        {
            if (Bricks[i] != null)
            {
                return true;
            }
        }
        return false;
    }
}
