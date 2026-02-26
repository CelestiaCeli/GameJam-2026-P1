using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    Camera mainCamera;

    public bool isFollowingPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.y > mainCamera.transform.position.y && isFollowingPlayer)
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerPos.position.y, mainCamera.transform.position.z);
    }
}
