using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Reference to the Mover component")]
    private Mover mover;

    private bool isFrozen = false;    // Local freeze state
    private Vector3 savedVelocity;   // To store velocity when freezing

    void Awake()
    {
        mover = GetComponent<Mover>();
    }

    // Start the freeze effect via a coroutine
    public void ApplyFreeze(float duration)
    {
        if (!isFrozen)
        {
            StartCoroutine(FreezeCoroutine(duration)); // Start the coroutine
        }
    }

    // Coroutine to handle the freeze and unfreeze process
    private IEnumerator FreezeCoroutine(float duration)
    {
        if (mover != null)
        {
            savedVelocity = mover.GetVelocity();
            mover.SetVelocity(Vector3.zero); // Stop movement
        }

        isFrozen = true;

        // Wait for the specified duration before unfreezing
        yield return new WaitForSeconds(duration);

        // After waiting, unfreeze the enemy
        Unfreeze();
    }

    // Unfreeze the enemy and restore movement
    private void Unfreeze()
    {
        if (isFrozen)
        {
            if (mover != null)
            {
                mover.SetVelocity(savedVelocity); // Restore movement
            }

            isFrozen = false;
        }
    }
}