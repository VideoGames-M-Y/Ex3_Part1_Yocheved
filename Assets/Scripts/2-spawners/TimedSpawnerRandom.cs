using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    [SerializeField] private Mover prefabToSpawn;
    [SerializeField] private Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField] private float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField] private float maxTimeBetweenSpawns = 1.0f;
    [SerializeField] private Transform parentOfAllInstances;

    void Start()
    {
        SpawnRoutine();
    }

    private async void SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds);
            if (!this) break;  // might be destroyed when moving to a new scene

            // Spawn the object at a random position
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-1.5f, 1.5f),
                transform.position.y,
                transform.position.z);
            
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            newObject.transform.parent = parentOfAllInstances;
        }
    }
}
