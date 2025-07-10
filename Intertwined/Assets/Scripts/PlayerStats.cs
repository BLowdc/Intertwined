using Unity.Mathematics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 50;
    public int MaxMana => maxMana;
    private int health;
    [SerializeField] private float mana;
    public float Mana => mana;
    [SerializeField] private float manaRegenRate = 5f;
    [SerializeField] private float manaDrainRate = 10f;
    private PlayerController playerController;
    private float invincibilityDuration = 1f;
    private float lastHit;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        health = maxHealth;
        mana = maxMana;
        lastHit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.IsSprinting && mana > 0)
        {
            mana -= manaDrainRate * Time.deltaTime;
            if (mana < 0) mana = 0;
            // Debug.Log($"Draining Mana: {mana}");
        }

        if (!playerController.IsSprinting && mana < maxMana)
        {
            mana += manaRegenRate * Time.deltaTime;
            if (mana > maxMana) mana = maxMana;
            // Debug.Log($"Regening Mana: {mana}");
        }

        lastHit += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox") && lastHit >= invincibilityDuration)
        {
            health -= collision.GetComponentInParent<EnemyStats>().Damage;
            lastHit = 0f;
            if (health <= 0)
            {
                health = 0;
                // player dies
            }
            Debug.Log(health);
        }
    }
}
