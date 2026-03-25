using UnityEngine;

public class BossRoomCloseGate : MonoBehaviour
{
    public GameObject gate;

    // when players step goes through the gate, close gate
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            gate.SetActive(true);
            Destroy(gameObject);
        }
    }
}
