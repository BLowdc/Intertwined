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
        // stores time since last shot
        lastShot = Time.time;
    }
    void Update()
    {
        // increments by frame time (time between each frame) every frame
        lastShot += Time.deltaTime;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        // checks if shoot button is pressed
        if (context.started)
        {
            // shoot projectile only if enough time is passed since last shot
            if (lastShot >= cooldown)
            {
                Strike();
                lastShot = 0f;
            }
        }
    }

    private void Strike()
    {
        // instantiates projectile at player position
        proj = Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
