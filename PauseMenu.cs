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

        // Cursor starts locked so the player can look around immediately
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
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

        // Unlock cursor when paused so the player can use the menu;
        // re-lock when resuming so MouseLook works again
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
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
