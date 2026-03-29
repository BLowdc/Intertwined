using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Camera Cam1;
    [SerializeField] private int damage = 10;
    public int Damage => damage;
    [SerializeField] private float speed = 5f;
    private Vector3 direction;
    void Awake()
    {
        Cam1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Start()
    {
        // converts mouse coordinates from screen to game world coordinates
        Vector3 mousePosition = Cam1.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // calculates the direction from player position to mouse position
        direction = mousePosition - transform.position;

        // Debug.Log("Direction: " + direction);
    }

    void FixedUpdate()
    {
        // moves the projectile in set direction
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // calculates damage if an enemy is hit
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
