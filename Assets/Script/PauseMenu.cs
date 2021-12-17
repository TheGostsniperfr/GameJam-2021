using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public AudioSource audioSource;

    public GameObject pauseMenuIU;
    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    void Paused()
    {
        PlayerMouvement.instance.enabled = false;
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        //audioSource.Pause();

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void Resume()
    {
        PlayerMouvement.instance.enabled = true;
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        settingsWindow.SetActive(false);
        //audioSource.Play();
    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoad.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
        
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
    }
}
