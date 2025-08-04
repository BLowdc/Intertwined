using UnityEngine;

public class BossEnemySpawn : MonoBehaviour
{
    public GameObject boss;
    private EnemyStats bossHealth;
    [SerializeField] private GameObject[] enemy;
    private bool reached75 = false;
    private bool reached50 = false;
    private bool reached25 = false;
    void Start()
    {
        bossHealth = boss.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reached75 && bossHealth.currentHealth <= bossHealth.maxHealth * 0.75)
        {
            SpawnEnemy(1);
            reached75 = true;
        }
        if (!reached50 && bossHealth.currentHealth <= bossHealth.maxHealth * 0.5)
        {
            SpawnEnemy(2);
            reached50 = true;
        }
        if (!reached25 && bossHealth.currentHealth <= bossHealth.maxHealth * 0.25)
        {
            SpawnEnemy(3);
            reached25 = true;
        }
    }
    private void SpawnEnemy(int n)
    {
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(0, 2);
            Instantiate(enemy[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
