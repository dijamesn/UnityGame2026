using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;           // Assign the pause menu panel in Inspector
    public GameManager gameManager; // Optional: hook into existing GameManager if you want

    private bool isPaused = false;

    void Start()
    {
        if (ui != null)
        {
            ui.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (ui != null)
            ui.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;

        // Optional: if you use a UIManager, you could notify it here
        // e.g. gameManager.SetPaused(isPaused);
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
        // Adjust this index/name for your main menu scene
        SceneManager.LoadScene(0);
    }
}