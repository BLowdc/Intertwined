using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class RespawnPlayerManager : MonoBehaviour
{
    public void RespawnPlayer(PlayerStats player, float delay)
    {
        StartCoroutine(RespawnCoroutine(player, delay));
    }
    public IEnumerator RespawnCoroutine(PlayerStats player, float delay)
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        player.gameObject.SetActive(true);
        player.SetHealth(player.MaxHealth);
        player.SetMana(player.MaxMana);
    }
}
