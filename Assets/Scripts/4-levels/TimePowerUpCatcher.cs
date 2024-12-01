using UnityEngine;

public class TimePowerUpCatcher : MonoBehaviour
{
    private string PowerUpTag = "Time";
    [SerializeField] private float freezeDuration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PowerUpTag))
        {
            Destroy(other.gameObject);
            ApplyFreezeToAllEnemies(freezeDuration);
        }
    }
    private void ApplyFreezeToAllEnemies(float duration)
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.ApplyFreeze(duration);
        }
    }
}