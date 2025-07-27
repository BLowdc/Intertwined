using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private GameObject proj;
    private float cooldown = 0.5f;
    private float lastShot;

    void Start()
    {
        lastShot = Time.time;
    }
    void Update()
    {
        lastShot += Time.deltaTime;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (lastShot >= cooldown)
            {
                Strike();
                lastShot = 0f;
            }
        }
    }

    private void Strike()
    {
        proj = Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
