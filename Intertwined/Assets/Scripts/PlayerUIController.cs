using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;
    private PlayerStats playerStats;
    public bool isHealth;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        if (isHealth)
        {
            if (player != null)
            {
                UpdateSlider(playerStats.Health, playerStats.MaxHealth);
            }
        }
        else
        {
            if (player != null)
            {
                UpdateSlider(playerStats.Mana, playerStats.MaxMana);
            }
        }
    }

    private void UpdateSlider(float currentValue, float maxValue)
    {
        if (slider != null)
        {
            slider.value = currentValue / maxValue;
        }
    }
}
