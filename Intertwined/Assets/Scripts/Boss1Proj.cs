using UnityEngine;

public class Boss1Proj : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 5f;
    void Update()
    {
        // moves the projectile horizontally

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if projectile collides with either players, perform damage calculations

        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);
        }

        // removes projectile from scene

        Destroy(gameObject);
    }
}
