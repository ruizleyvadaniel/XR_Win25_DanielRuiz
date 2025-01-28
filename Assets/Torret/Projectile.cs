using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        // Deactivate after delay
        [SerializeField] private float timeoutDelay = 3f;

        public void Deactivate()
        {
            StartCoroutine(DeactivateRoutine(timeoutDelay));
        }

        IEnumerator DeactivateRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);

            // Reset the moving Rigidbody
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.linearVelocity = new Vector3(0f, 0f, 0f);
            rBody.angularVelocity = new Vector3(0f, 0f, 0f);

            // Destroy
            Destroy(this);
        }
    }

