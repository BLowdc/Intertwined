using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;
    [SerializeField] private Text score;
    private PlayerStats playerStats;
    public bool isHealth;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        if (player != null && slider != null)
        {
            if (isHealth)
            {
                UpdateSlider(playerStats.Health, playerStats.MaxHealth);
            }
            else
            {              
                UpdateSlider(playerStats.Mana, playerStats.MaxMana);   
            }
        }

        if (player != null && score != null)
        {
            score.text = $"Score: {playerStats.Score}";
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
