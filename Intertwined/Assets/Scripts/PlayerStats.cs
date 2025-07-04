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
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        health = maxHealth;
        mana = maxMana;
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
    }
}
