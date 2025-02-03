using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShootingTower_OOP : Enemy
{
    [SerializeField] private Transform m_torret;
    [SerializeField] private Projectile m_projectilePrefab;

    private void Start()
    {
        m_attackRange = 10;
    }
    protected override void Attack()
    {
        base.Attack();

        AimTorret(m_playerTarget);
        Fire();
    }

    private void AimTorret(Transform target)
    {
        if (m_torret == null) return;

        // Get the direction from the object to the player
        Vector3 direction = m_playerTarget.position - m_torret.position;

        // Zero out the Y component to prevent rotation on the vertical axis
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            // Create a rotation towards the target while ignoring vertical rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            m_torret.rotation = targetRotation;
        }
    }

    private void Fire()
    {
        if (m_projectilePrefab != null && m_torret != null)
        {
            Projectile projectile = Instantiate(m_projectilePrefab, m_torret.position, m_torret.rotation);
            projectile.Shoot(m_attackDamage);
        }
        
    }

    protected override void Destroy()
    {
        throw new System.NotImplementedException();
    }

}
