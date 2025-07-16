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
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultPlate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Box"))
        {
            spriteRenderer.sprite = pressedPlate;
            isPressed = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Box"))
        {
            spriteRenderer.sprite = defaultPlate;
            isPressed = false;
        }
    }
}
