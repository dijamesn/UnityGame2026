using UnityEngine;

// Attach this to the FPS Camera (child of the Player).
// It automatically disables itself when the FPS camera's GameObject is inactive,
// so it won't conflict with the overhead camera mode.
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Update()
    {
        // Do nothing when this camera's GameObject has been deactivated by CameraController
        if (!gameObject.activeInHierarchy)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
