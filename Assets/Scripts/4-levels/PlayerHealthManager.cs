using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;

    public int health = 3; // Initial health
    [SerializeField] private int maxHealth = 5; 
    [SerializeField] TMP_Text healthText;
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
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
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
            UpdateHealthDisplay(); 
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
            IncreaseHealth();
            Destroy(other.gameObject);
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
