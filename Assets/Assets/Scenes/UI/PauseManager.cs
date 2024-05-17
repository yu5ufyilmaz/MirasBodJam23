using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(false); // Pause ekranını aç
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(true); // Pause ekranını kapat
        isPaused = false;
    }
}
