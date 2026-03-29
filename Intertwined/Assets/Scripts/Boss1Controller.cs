using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private float speed = 3f;
    private float distance1; // Distance to player1
    private float distance2; // Distance to player2
    [SerializeField] private float aggroRange = 20f; //aggrovation range
    [SerializeField] private GameObject projectile;
    private float fireRate;
    private float lastFire;

    // Update is called once per frame
    void Start()
    {
        fireRate = 1.5f;
        lastFire = Time.time;
    }
    void Update()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");

        // if both players are dead, no nothing

        if (player1 == null && player2 == null)
        {
            return;
        }

        // if only player 1 is dead, target player 2

        else if (player1 == null)
        {
            distance2 = (player2.transform.position - transform.position).magnitude;
            if (distance2 < aggroRange)
            {
                Target(player2);
            }
        }

        // if only player 2 is dead, target player 1

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
            // both players are alive, calculate distances to both

            distance1 = (player1.transform.position - transform.position).magnitude;
            distance2 = (player2.transform.position - transform.position).magnitude;

            // decide which is closer, taget nearest player

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

        // ------------SHOOTING LOGIC------------

        // check if enough time has passed since last shot

        if (lastFire > fireRate)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -90));

            // reset timer 

            lastFire = 0f;
        }

        // increment timer using frame time

        lastFire += Time.deltaTime;
    }

    // moves the boss vertically towards the target player
    public void Target(GameObject player)
    {
        if (player.transform.position.y > transform.position.y)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
