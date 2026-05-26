using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;           // Assign the pause menu panel in the Inspector
    public GameManager gameManager;

    private bool isPaused = false;

    void Start()
    {
        if (ui != null)
            ui.SetActive(false);

        Time.timeScale = 1f;

        // Always spawn with mouse visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (ui != null)
            ui.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;

        // Show cursor whenever the menu is open; hide when closed
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
    }

    public void Resume()
    {
        if (!isPaused) return;
        TogglePause();
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
