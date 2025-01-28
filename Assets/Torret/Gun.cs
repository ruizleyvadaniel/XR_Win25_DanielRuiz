using UnityEngine;
using UnityEngine.Events;


    public class Gun : MonoBehaviour
    {
        [Tooltip("Prefab to shoot")]
        [SerializeField] private Projectile projectilePrefab;
        [Tooltip("Projectile force")]
        [SerializeField] private float muzzleVelocity = 1500f;
        [Tooltip("End point of gun where shots appear")]
        [SerializeField] private Transform muzzlePosition;
        [Tooltip("Time between shots / smaller = higher rate of fire")]
        [SerializeField] private float cooldownWindow = 0.1f;

        [SerializeField] private UnityEvent m_GunFired;

        private float nextTimeToShoot;


        private void FixedUpdate()
        {
          /*  // Shoot if we have exceeded delay
            if (Input.GetButton("Fire1") && Time.time > nextTimeToShoot && objectPool != null)
            {
                Shoot();
            }*/
        }

        public void Shoot()
        {
            // Instantiate a bullet
            Projectile bulletObject = Instantiate(projectilePrefab);

            if (bulletObject == null)
                return;

            // Align to gun barrel/muzzle position
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            // Move projectile forward
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);

            // Turn off after a few seconds
            bulletObject.Deactivate();

            // Set cooldown delay
            nextTimeToShoot = Time.time + cooldownWindow;

            m_GunFired.Invoke();
        }
    }

