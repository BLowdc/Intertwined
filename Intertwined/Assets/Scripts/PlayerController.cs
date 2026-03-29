using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private bool isSprinting;
    public bool IsSprinting => isSprinting;
    private PlayerControls playerControls;
    private PlayerStats playerStats;
    private Vector2 movement;
    private Rigidbody2D rb;
    private int sprintMultiplier = 2;
    // private SpriteRenderer spriteRenderer;
    private bool sprintkeyHeld;

    
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            sprintkeyHeld = true;
        }
        else if (context.canceled)
        {
            sprintkeyHeld = false;
        }
    }

    // Handles sprint logic and rotation
    void Update()
    {
        // Enables sprinting if key is held and player has sufficient mana
        if (sprintkeyHeld && playerStats.Mana > playerStats.MaxMana * 0.25f)
        {
            if (!isSprinting)
            {
                moveSpeed *= sprintMultiplier;
                isSprinting = true;
            }
        }

        // stops sprinting ifkey is release or insufficient mana
        else if (!sprintkeyHeld || playerStats.Mana <= 0)
        {
            if (isSprinting)
            {
                moveSpeed /= sprintMultiplier;
                isSprinting = false;
            }
        }

        // makes player face the direction they are moving in
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    // moves the player
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed);
    }
}