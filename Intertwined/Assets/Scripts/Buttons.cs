using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        GameObject.Find("Pause Screen").SetActive(false);
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
