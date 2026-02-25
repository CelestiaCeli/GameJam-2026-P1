using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.y > (Screen.height / 2))
        {
            Debug.Log("MOVE THAT CAMERA!");
            mainCamera.transform.position = new Vector3(0, playerPos.position.y, 0);
        }
    }
}
