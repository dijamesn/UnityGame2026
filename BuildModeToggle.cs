using UnityEngine;

// B key for build mode has been removed.
// Mouse is unlocked on spawn by default.
// Cursor state is now managed by PauseMenu (Escape) and CameraController (Tab).
public class BuildModeToggle : MonoBehaviour
{
    public static bool InBuildMode = true; // Always in build mode now; toggle was removed

    public MouseLook mouseLook;

    void Start()
    {
        // Spawn with mouse visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;

        if (mouseLook != null)
            mouseLook.enabled = false;
    }
}
