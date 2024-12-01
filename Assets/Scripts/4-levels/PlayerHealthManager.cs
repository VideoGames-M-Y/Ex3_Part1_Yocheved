using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    // Singleton instance
    public static PlayerHealthManager Instance;

    // Make health public for easy access from other scripts
    public int health = 3; // Initial health
    [SerializeField] private int maxHealth = 5; // Maximum health
    [SerializeField] TMP_Text healthText; // Reference to TextMeshPro for health display
    string HealthTag = "Health";

    [SerializeField] [Tooltip("Name of scene to move to when health reaches 0")] string sceneName;

    void Awake()
    {
        // Singleton pattern: if there's already an instance, destroy the duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Keep the object between scene loads
        }
    }

    void Start()
    {
        UpdateHealthDisplay();
    }

    // Decrease health when hit by an enemy
    public void DecreaseHealth()
    {
        if (health > 0)
        {
            health--; // Decrease health
            UpdateHealthDisplay(); // Update health display
        }
    }

    // Increase health when picking up a heart
    public void IncreaseHealth()
    {
        if (health < maxHealth)
        {
            health++; // Increase health
            UpdateHealthDisplay(); // Update health display
        }
    }

    // Handle collision with hearts directly in this script
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(HealthTag))
        {
            IncreaseHealth(); // Increase health when collecting a heart
            Destroy(other.gameObject); // Remove the heart
        }
    }

    // Update the health display
    private void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
}