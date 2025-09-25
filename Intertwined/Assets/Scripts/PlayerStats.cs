using System.Collections;
using Unity.Mathematics;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth => maxHealth;
    [SerializeField] private int maxMana = 50;
    public int MaxMana => maxMana;
    [SerializeField] private int health;
    public int Health => health;
    [SerializeField] private float mana;
    public float Mana => mana;
    [SerializeField] private float manaRegenRate = 5f;
    [SerializeField] private float manaDrainRate = 10f;
    private PlayerController playerController;
    private float invincibilityDuration = 1f;
    private float lastHit;
    private RespawnPlayerManager respawnPlayerManager;
    [SerializeField] private float respawnTime = 5f;
    private int score = 0;
    public int Score => score;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        respawnPlayerManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<RespawnPlayerManager>();
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

    public void TakeDamage(int damage)
    {
        if (lastHit < invincibilityDuration) return;

        health -= damage;
        lastHit = 0f;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        respawnPlayerManager.RespawnPlayer(this, respawnTime);
    }

    public void SetHealth(int newHealth)
    {
        health = Mathf.Clamp(newHealth, 0, maxHealth);
    }

    public void SetMana(int newMana)
    {
        mana = Mathf.Clamp(newMana, 0, maxMana);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            score += 50;
            Destroy(other.gameObject);
        }
    }
}