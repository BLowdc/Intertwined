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
        Vector3 mousePosition = Cam2.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = mousePosition - transform.position;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        gameObject.transform.position = transform.position + direction.normalized * 0.5f;
        Destroy(gameObject, 0.2f);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
    }
}
