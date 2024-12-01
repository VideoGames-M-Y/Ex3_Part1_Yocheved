using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

public class GotoNextLevel : MonoBehaviour {
    [SerializeField] string triggeringTag;

    string EnemyTag = "Enemy";  // Use double quotes for strings
    string NextLevelTag = "ToNextLevel";

    [SerializeField] [Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;

    [SerializeField] PlayerHealthManager healthManager;  // Reference to PlayerHealthManager

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(triggeringTag)) {
        if (triggeringTag == EnemyTag) {
            // Call DecreaseHealth() when touching an enemy
            PlayerHealthManager.Instance.DecreaseHealth();

            // If health is 0, end the game and load the scene
            if (PlayerHealthManager.Instance.health <= 0) {
                other.transform.position = Vector3.zero;  // Optional: reset enemy position
                SceneManager.LoadScene(sceneName);  // Game Over (end the game)
            }
        } else if (triggeringTag == NextLevelTag) {
            // Proceed to next level if the player touches the 'NextLevel' trigger
            other.transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);  // Next Level
        }
    }
    }
}