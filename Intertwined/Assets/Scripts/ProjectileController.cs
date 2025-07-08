using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    public int Damage => damage;
    [SerializeField] private float speed = 5f;
    private Vector3 direction;
    void Awake()
    {
        // Debug.Log(transform.position);
    }
    void Start()
    {
        direction = Input.mousePosition - transform.position;
    }

    void FixedUpdate()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
