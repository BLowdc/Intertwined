using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private float speed = 1f;
    private float distance1; // Distance to player1
    private float distance2; // Distance to player2
    private Vector3 direction; 
    [SerializeField] private float aggroRange = 3f;

    // Update is called once per frame
    void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }
    void FixedUpdate()
    {
        distance1 = (player1.transform.position - transform.position).magnitude;
        distance2 = (player2.transform.position - transform.position).magnitude;
        // Debug.Log(distance1 + " " + distance2); 
        if (distance1 < aggroRange || distance2 < aggroRange)
        {
            Move();
        }
    }

    public void Move()
    {
        if (distance1 < distance2)
        {
            direction = (player1.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            direction = (player2.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }   
}

