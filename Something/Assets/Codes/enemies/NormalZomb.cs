using UnityEngine;

public class NormalZomb : EnemyBase
{
    public float attackRange = 1.5f;
    public int attackDamage = 1;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    protected override void Update()
    {
        base.Update();
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Attack();
        }
    }
    private void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
        }
    }
    protected override void Die()
    {
        base.Die();
    }
}
