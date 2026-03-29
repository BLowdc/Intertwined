using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    private Camera Cam2;
    [SerializeField] private int damage = 35;
    public int Damage => damage;
    private Vector3 direction;
    void Awake()
    {
        Cam2 = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();
    }
    void Start()
    {
        // converts mouse coordinates from screen to game world coordinates
        Vector3 mousePosition = Cam2.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // calculates the direction from player position to mouse position
        direction = mousePosition - transform.position;

        // makes the weapon face towards the mouse
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // gives the weapon an offset to appear in front if the player
        gameObject.transform.position = transform.position + direction.normalized * 0.5f;
        Destroy(gameObject, 0.2f);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // calculates damage if an enemy is hit
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
    }
}
