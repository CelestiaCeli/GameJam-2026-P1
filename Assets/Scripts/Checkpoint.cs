using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    GameObject[] Bricks;
    [SerializeField]
    CameraFollow mainCamera;
    [SerializeField]
    Vector3 teleportPoint;

    // Update is called once per frame
    void Update()
    {
        if (!CheckBricks())
        {
            mainCamera.isFollowingPlayer = true;
            Destroy(this.gameObject);
            TeleportPlayer();
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

    void TeleportPlayer()
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = teleportPoint;
    }
}
