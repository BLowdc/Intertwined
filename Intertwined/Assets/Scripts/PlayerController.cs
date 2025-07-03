using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

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
    private SpriteRenderer spriteRenderer;
    private bool sprintkeyHeld;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    // Update is called once per frame
    void Update()
    {
        if (sprintkeyHeld && playerStats.Mana > playerStats.MaxMana * 0.25f)
        {
            if (!isSprinting)
            {
                moveSpeed *= sprintMultiplier;
                isSprinting = true;
            }
        }
        else if (!sprintkeyHeld || playerStats.Mana <= 0)
        {
            if (isSprinting)
            {
                moveSpeed /= sprintMultiplier;
                isSprinting = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}

