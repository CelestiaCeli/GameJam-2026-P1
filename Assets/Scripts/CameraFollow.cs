using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    Camera mainCamera;

    private GameObject cameraSmoothObject;

    private bool smoothBoot = false;

    private const float offSet = 0.1f;
    
    private float timeSmooth = 0;

    [SerializeField] private float speed = 3;
    private Vector3 mainCameraDesired;

    public bool isFollowingPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.transform.position.y > mainCamera.transform.position.y && !smoothBoot)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerPos.position.y, mainCamera.transform.position.z);

        if (smoothBoot)
        {
            timeSmooth += Time.deltaTime * speed;
            mainCamera.transform.position = Vector3.Lerp(cameraSmoothObject.transform.position, mainCameraDesired, timeSmooth);
            float difference = Vector2.Distance(mainCamera.transform.position, mainCameraDesired);
            
            Debug.Log(cameraSmoothObject.transform.localPosition);
            Debug.Log(mainCameraDesired);
            Debug.Log(difference);
            if (difference < offSet)
            {
                smoothBoot = false;
            }
        }
    }

    public void SmoothBoot(GameObject _exCamera)
    {
        cameraSmoothObject = _exCamera;
        mainCameraDesired = new Vector3(mainCamera.transform.position.x, playerPos.position.y, mainCamera.transform.position.z);
        smoothBoot = true;
        
    }
}
