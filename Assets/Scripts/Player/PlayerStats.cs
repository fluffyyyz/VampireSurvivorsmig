using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LevelRange
{
    public int startLevel;
    public int endLevel;
    public int experienceCapIncrease;
}

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    // Current stats
    public float currentHealth;
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentMight;
    [HideInInspector] public float currentProjectileSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    // Class for defining level ranges
    public List<LevelRange> levelRanges;

    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    // Reference to the Game Over Canvas
    public GameObject gameOverCanvas;

    void Awake()
    {
        // Initialize player stats from the character data
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;

        // Set the initial experience cap based on the first level range
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("PLAYER IS DEAD");

        // Enable the Game Over Canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Destroy the player object
        Destroy(gameObject);
    }

    // Method to increase experience
    public void IncreaseExperience(int amount)
    {
        experience += amount;  // Add experience
        LevelUpChecker();      // Check if player can level up
    }

    // Method to check if the player levels up
    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;  // Increase the player's level
            experience -= experienceCap;  // Reduce the experience by the cap value

            // Adjust experience cap based on level range
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCap = range.experienceCapIncrease;
                    break;
                }
            }

            Debug.Log("Player leveled up to level " + level);
        }
    }
}
