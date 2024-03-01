using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3; // Total number of hearts
    public float hitValue = 0.5f; // Value of damage taken per hit

    private int currentHealth; // Current health represented by hearts

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum
    }

    // Function to take damage
    public void TakeDamage()
    {
        currentHealth -= Mathf.CeilToInt(hitValue); // Reduce health by hitValue (rounded up)
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        UpdateHealthUI(); // Update UI to reflect current health
        if (currentHealth <= 0)
        {
            Die(); // Call Die function when health reaches 0 or below
        }
    }

    // Function to update UI (You can replace this with your own UI update logic)
    void UpdateHealthUI()
    {
        Debug.Log("Current Health: " + currentHealth); // Example: Log current health to console
        // You can implement your own UI update logic here to represent health visually
    }

    // Function to handle death
    void Die()
    {
        Debug.Log("Player died!"); // Example: Log death message to console
        // You can implement your own game over logic here
    }
}

