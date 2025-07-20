using UnityEngine;

public class SpawnBoss1 : MonoBehaviour
{
    public GameObject boss;
    public GameObject spawner1;
    public GameObject spawner2;
    void Start()
    {
        boss.SetActive(false);
        spawner1.SetActive(false);
        spawner2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            boss.SetActive(true);
            spawner1.SetActive(true);
            spawner2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
