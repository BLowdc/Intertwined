using UnityEngine;

public class SpawnBoss1 : MonoBehaviour
{
    public GameObject boss;
    public GameObject spawner1;
    public GameObject spawner2;
    void Start()
    {
        // Disable boss and its spawners at the start
        boss.SetActive(false);
        spawner1.SetActive(false);
        spawner2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When either player steps into boss arena, activate boss and spawners
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            boss.SetActive(true);
            spawner1.SetActive(true);
            spawner2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
