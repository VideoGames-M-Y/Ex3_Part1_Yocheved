using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;
    public int health = 3;
    [SerializeField] private int maxHealth = 5; 
    [SerializeField] TMP_Text healthText; 
    string HealthTag = "Health";

    [SerializeField] [Tooltip("Name of scene to move to when health reaches 0")] string sceneName;

    void Awake()
    {
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
    public void DecreaseHealth()
    {
        if (health > 0)
        {
            health--;
            UpdateHealthDisplay();
        }
    }
    public void IncreaseHealth()
    {
        if (health < maxHealth)
        {
            health++; 
            UpdateHealthDisplay();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(HealthTag))
        {
            IncreaseHealth(); 
            Destroy(other.gameObject);
        }
    }

    private void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
}