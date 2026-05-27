using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject overheadCamera;

    public KeyCode toggleKey = KeyCode.Tab;
    public bool startInFPS = true;

    private bool isFPSMode;

    void Start()
    {
        isFPSMode = startInFPS;
        ApplyMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isFPSMode = !isFPSMode;
            ApplyMode();
        }
    }

    void ApplyMode()
    {
        if (fpsCamera != null)
            fpsCamera.SetActive(isFPSMode);

        if (overheadCamera != null)
            overheadCamera.SetActive(!isFPSMode);

        if (isFPSMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public bool IsFPSMode()
    {
        return isFPSMode;
    }
}