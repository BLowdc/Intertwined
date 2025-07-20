using UnityEngine;

public class SpawnEnemies1 : MonoBehaviour
{
    public GameObject enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            enemies.SetActive(true);
            Destroy(gameObject);
        }
    }
}
