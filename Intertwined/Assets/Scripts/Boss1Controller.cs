using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private float speed = 3f;
    private float distance1; // Distance to player1
    private float distance2; // Distance to player2
    [SerializeField] private float aggroRange = 20f;
    [SerializeField] private GameObject projectile;
    private float fireRate;
    private float lastFire;

    // Update is called once per frame
    void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        fireRate = 2f;
        lastFire = Time.time;
    }
    void Update()
    {
        distance1 = (player1.transform.position - transform.position).magnitude;
        distance2 = (player2.transform.position - transform.position).magnitude;
        // Debug.Log(distance1 + " " + distance2); 
        if (distance1 < aggroRange || distance2 < aggroRange)
        {
            Move();
        }
        if (lastFire > fireRate)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -90));
            lastFire = 0f;
        }
        lastFire += Time.deltaTime;
    }

    public void Move()
    {
        if (distance1 < distance2)
        {
            if (player1.transform.position.y > transform.position.y)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        else
        {
            if (player2.transform.position.y > transform.position.y)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }
}   
