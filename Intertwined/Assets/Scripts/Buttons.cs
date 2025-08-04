using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    private GameObject pauseScreen;
    private GameObject playerStats;
    private GameObject controlsScreen;
    void Start()
    {
        pauseScreen = GameObject.Find("Pause Screen");
        playerStats = GameObject.Find("Player Stats");
        controlsScreen = GameObject.Find("Controls Screen");
        if (pauseScreen != null && playerStats != null && controlsScreen != null)
        {
            pauseScreen.SetActive(false);
            playerStats.SetActive(true);
            controlsScreen.SetActive(false);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void ShowControls()
    {
        controlsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void HideControls()
    {
        controlsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        playerStats.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
