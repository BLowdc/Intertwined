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
        if (enemyStats != null)
        {
            UpdateHealthBar(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }
    public void UpdateHealthBar(int currentHP, int maxHP)
    {
        slider.value = (float)currentHP / (float)maxHP;
    }
}
