using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private float speed = 1f;
    private float distance1; // Distance to player1
    private float distance2; // Distance to player2
    private Vector3 direction; // Direction enemy moves in
    [SerializeField] private float aggroRange = 10f;
    private EnemyStats enemyStats;

    // Update is called once per frame
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }
    void Update()
    {
        // Finds both players in scene

        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");

        // if both players dead, do nothing

        if (player1 == null && player2 == null)
        {
            return;
        }

        // if only player 1 dead, target player 2

        else if (player1 == null)
        {
            distance2 = (player2.transform.position - transform.position).magnitude;
            if (distance2 < aggroRange)
            {
                Target(player2);
            }
        }

        // if only player 2 dead, target player 1

        else if (player2 == null)
        {
            distance1 = (player1.transform.position - transform.position).magnitude;
            if (distance1 < aggroRange)
            {
                Target(player1);
            }
        }

        else
        {
            // calculates distance to both players

            distance1 = (player1.transform.position - transform.position).magnitude;
            distance2 = (player2.transform.position - transform.position).magnitude;

            // selects closer target and targets when within aggrovation range

            if (distance1 < distance2)
            {
                if (distance1 < aggroRange)
                {
                    Target(player1);
                }
            }
            else
            {
                if (distance2 < aggroRange)
                {
                    Target(player2);
                }
            }
        }

        // makes the enemy face to correct way when moving

        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // moves the enemy towards the player
    public void Target(GameObject player)
    {
        direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    // deals damage if enemy touches player
    private void OnCollisionStay2D(Collision2D collision)
    { 
        PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(enemyStats.Damage);
        }
    }
}