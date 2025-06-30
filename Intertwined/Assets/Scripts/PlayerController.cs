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

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        Debug.Log(playerStats.Mana);

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerStats.Mana > playerStats.MaxMana * 0.25f)
        {
            moveSpeed *= sprintMultiplier;
            isSprinting = true;
            spriteRenderer.color = Color.green;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || playerStats.Mana <= 0)
        {
            moveSpeed = 3f;
            isSprinting = false;
            spriteRenderer.color = Color.white;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>(); 
    }
    
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}

