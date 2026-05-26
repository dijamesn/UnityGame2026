using UnityEngine;

// B key for build mode removed.
// Mouse starts LOCKED so the player can look around with MouseLook.
// PauseMenu (Escape) is responsible for unlocking/relocking the cursor.
public class BuildModeToggle : MonoBehaviour
{
    public static bool InBuildMode = true;

    public MouseLook mouseLook;

    void Start()
    {
        // Lock the cursor on spawn so MouseLook can rotate the player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;

        if (mouseLook != null)
            mouseLook.enabled = true;
    }
}
