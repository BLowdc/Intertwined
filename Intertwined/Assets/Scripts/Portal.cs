using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Loads next scene when either player enters the portal
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player1") || collider.CompareTag("Player2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
