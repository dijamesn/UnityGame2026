using UnityEngine;

// Attach this script to your overhead Camera GameObject.
// Assign the fpsCameraObject field in the Inspector to your FPS Camera (the one with MouseLook).
// Press Tab at runtime to toggle between FPS and Overhead mode.
public class CameraController : MonoBehaviour
{
    [Header("Overhead Camera Settings")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    [Header("Camera Toggle")]
    // Drag your FPS camera (the child of the Player that has MouseLook) here.
    public GameObject fpsCameraObject;

    // True  = FPS mode  (fpsCameraObject active,  this overhead camera disabled)
    // False = Overhead mode (this overhead camera active, fpsCameraObject disabled)
    private bool isFPSMode = false;

    void Start()
    {
        ApplyCameraMode();
    }

    void Update()
    {
        // Toggle on Tab press
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFPSMode = !isFPSMode;
            ApplyCameraMode();
        }

        // Only run overhead panning/scrolling when in overhead mode
        if (isFPSMode)
            return;

        Vector3 forward = transform.forward;
        Vector3 right   = transform.right;

        forward.y = 0f;
        right.y   = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            moveDirection += forward;
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            moveDirection -= forward;
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            moveDirection += right;
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            moveDirection -= right;

        transform.position += moveDirection.normalized * panSpeed * Time.deltaTime;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos  = transform.position;
        pos.y += scroll * 1000f * scrollSpeed * Time.deltaTime;
        pos.y  = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void ApplyCameraMode()
    {
        // Enable/disable the FPS camera
        if (fpsCameraObject != null)
            fpsCameraObject.SetActive(isFPSMode);

        // Enable/disable this overhead camera
        Camera overheadCam = GetComponent<Camera>();
        if (overheadCam != null)
            overheadCam.enabled = !isFPSMode;

        // Lock/unlock cursor for FPS feel
        if (isFPSMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
    }
}
