using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject playerStatsUI;
    private bool isPaused = false;

    void Start()
    {
        // sets the time in game to normal
        Time.timeScale = 1f;
    }
    void Update()
    {
        // pauses the game when escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                // stops time
                Time.timeScale = 0f;

                // brings up pause menu
                pauseMenuUI.SetActive(true);    

                // hides player HUD
                playerStatsUI.SetActive(false);                                                                                                                                                                               
            }
        }
    }
}
