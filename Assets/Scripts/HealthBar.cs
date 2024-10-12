using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerStats playerStats;  // Reference to the PlayerStats script
    public Image healthBarFill;      // The UI element (Image) representing the health bar fill

    void Update()
    {
        // Update the health bar based on the player's current health
        if (playerStats != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = playerStats.currentHealth / playerStats.characterData.MaxHealth;
        }
    }
}
