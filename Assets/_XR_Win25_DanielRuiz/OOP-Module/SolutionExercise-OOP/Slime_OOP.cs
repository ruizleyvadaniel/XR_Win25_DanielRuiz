using UnityEngine;

public class Slime_OOP : Enemy
{
    [SerializeField] private float m_moveSpeed = 0.5f;

    protected override void Update()
    {
        base.Update();

        if (!IsWithinAttackRange)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (m_playerTarget == null) return;

        transform.position = Vector3.MoveTowards(transform.position, m_playerTarget.position, m_moveSpeed * Time.deltaTime);
    }

    protected override void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
