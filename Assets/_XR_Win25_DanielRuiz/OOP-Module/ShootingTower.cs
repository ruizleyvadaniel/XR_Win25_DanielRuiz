using System.Collections;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private float m_attackRate = 3f;
    [SerializeField] private float m_attackRange = 10f;
    [SerializeField] private int m_attackDamage = 1;

    [SerializeField] private Transform m_torret;
    [SerializeField] private Projectile m_projectilePrefab;

    [field: SerializeField] public string Name { get; protected set; }

    private Coroutine attackCoroutine;

    private bool IsWithinAttackRange => Vector3.Distance(transform.position, m_playerTarget.position) < m_attackRange;

    private void Awake()
    {
        if (m_playerTarget == null) m_playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (IsWithinAttackRange)
            HandleAttack();
    }

    private void HandleAttack()
    {
        if (attackCoroutine == null)
            attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (IsWithinAttackRange)
        {
            Attack();
            yield return new WaitForSeconds(m_attackRate);
        }

        attackCoroutine = null; // Reset the coroutine reference when the enemy moves out of range
    }

    private void Attack()
    {
        Debug.Log($"{Name} is attacking with {m_attackDamage} damage!");

        AimTorret(m_playerTarget);
        Fire();
    }

    private void AimTorret(Transform target)
    {
        // Get the direction from the object to the player
        Vector3 direction = m_playerTarget.position - transform.position;

        // Zero out the Y component to prevent rotation on the vertical axis
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            // Create a rotation towards the target while ignoring vertical rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    private void Fire()
    {
        Projectile projectile = Instantiate(m_projectilePrefab, m_torret.position, m_torret.rotation);
        projectile.Shoot(m_attackDamage);
    }

    // Gizmo to draw the attack range as a green circle in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Set the gizmo color to green

        // Number of segments to approximate the circle
        int segments = 50;
        float angleStep = 360f / segments;

        // Draw the circle
        Vector3 previousPoint = transform.position + new Vector3(m_attackRange, 0f, 0f); // Start at the right side of the circle
        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad; // Convert angle to radians
            Vector3 newPoint = transform.position + new Vector3(Mathf.Cos(angle) * m_attackRange, 0f, Mathf.Sin(angle) * m_attackRange);
            Gizmos.DrawLine(previousPoint, newPoint); // Draw line from the previous point to the new point
            previousPoint = newPoint; // Move to the new point for the next line
        }
    }
}
