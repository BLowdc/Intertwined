using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private EnemyStats enemyStats;
    void Start()
    {
        enemyStats = GetComponentInParent<EnemyStats>();
    }

    void Update()
    {
        // Updates the health bar to match enemy's current health
        if (enemyStats != null)
        {
            UpdateHealthBar(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }

    // Calculates the value of the health bar using the ratio of currentHP to maxHP
    public void UpdateHealthBar(int currentHP, int maxHP)
    {
        slider.value = (float)currentHP / (float)maxHP;
    }
}
