using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite defaultPlate;
    public Sprite pressedPlate;
    private bool isPressed;
    public bool IsPressed => isPressed;
    void Start()
    {
        // Sets the appearance of pressure plate to default script
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultPlate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Activates plate if a player or a box is on it
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Box"))
        {
            // Changes sprite to activated plate
            spriteRenderer.sprite = pressedPlate;
            isPressed = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Deactivates plate if player or box leaves
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Box"))
        {
            // Changes sprite back to default plate
            spriteRenderer.sprite = defaultPlate;
            isPressed = false;
        }
    }
}
