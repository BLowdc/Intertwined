using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private int damage = 10;
    public int Damage => damage;
    public GameObject portal; 
    [SerializeField] private Vector3 portalPosition;

    void Awake()
    {

    }
    void Start()
    {
        // sets health to max health upon instantiation
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // ONLY FOR BOSS
        if (currentHealth <= 0)
        {
            // if portal object is attached to boss, then spawn portal when the boss dies

            if (portal != null)
            {
                Instantiate(portal, portalPosition, Quaternion.identity);
                Debug.Log("Portal spawned");
            }
            Destroy(gameObject);
        }
    }

    // calculates damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // prevents health from going below 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}
