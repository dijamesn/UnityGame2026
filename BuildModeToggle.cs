using UnityEngine;

public class BuildModeToggle : MonoBehaviour
{
    public static bool InBuildMode = true; 

    public MouseLook mouseLook;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;

        if (mouseLook != null)
            mouseLook.enabled = false;
    }
}