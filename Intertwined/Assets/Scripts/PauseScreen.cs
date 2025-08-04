using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject playerStatsUI;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                pauseMenuUI.SetActive(true);    
                playerStatsUI.SetActive(false);                                                                                                                                                                               
            }
        }
    }
}
