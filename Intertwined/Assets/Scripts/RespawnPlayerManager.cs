using System.Collections;
using UnityEngine;

public class RespawnPlayerManager : MonoBehaviour
{
    // Starts the respawn process for player after a delay
    public void RespawnPlayer(PlayerStats player, float delay)
    {
        StartCoroutine(RespawnCoroutine(player, delay));
    }

    // Coroutine that handles disabling, waiting, and re-enabling the player
    public IEnumerator RespawnCoroutine(PlayerStats player, float delay)
    {
        // Disables player game object
        player.gameObject.SetActive(false);

        // Wait for a specified respawn time
        yield return new WaitForSeconds(delay);

        // Re-enables the player with full health and mana
        player.gameObject.SetActive(true);
        player.SetHealth(player.MaxHealth);
        player.SetMana(player.MaxMana);
    }
}
