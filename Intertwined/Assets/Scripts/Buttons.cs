using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    public void TitleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start Screen");
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
