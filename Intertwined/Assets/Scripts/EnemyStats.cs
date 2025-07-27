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
        
        // Physics2D.IgnoreLayerCollision(3, 6, true);
        // Physics2D.IgnoreLayerCollision(3, 8, false); 
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (portal != null)
            {
                Instantiate(portal, portalPosition, Quaternion.identity);
                Debug.Log("Portal spawned");
            }
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}

    
