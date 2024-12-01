using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

public class GotoNextLevel : MonoBehaviour {
    [SerializeField] string triggeringTag;

    string EnemyTag = "Enemy";
    string NextLevelTag = "ToNextLevel";

    [SerializeField] [Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;

    [SerializeField] PlayerHealthManager healthManager;

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(triggeringTag)) {
        if (triggeringTag == EnemyTag) {
            PlayerHealthManager.Instance.DecreaseHealth();

            if (PlayerHealthManager.Instance.health <= 0) {
                other.transform.position = Vector3.zero;
                SceneManager.LoadScene(sceneName);
            }
        } else if (triggeringTag == NextLevelTag) {
            other.transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);
        }
    }
    }
}