using UnityEngine;

public class BuildModeToggle : MonoBehaviour
{
    public static bool InBuildMode = false;

    public MouseLook mouseLook;

    void Start()
    {
        SetBuildMode(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetBuildMode(!InBuildMode);
        }
    }

    void SetBuildMode(bool buildMode)
    {
        InBuildMode = buildMode;

        if (mouseLook != null)
        {
            mouseLook.enabled = !buildMode;
        }

        if (buildMode)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}