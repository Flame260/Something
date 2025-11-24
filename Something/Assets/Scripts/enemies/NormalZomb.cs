using UnityEngine;

public class NormalZomb : EnemyBase
{
    public float attackRange = 1.5f;
    public int attackDamage = 1;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;

    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();

        if(Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            currentState = zombieState.damage;
        }
    }

    protected override void attackPlayer()
    {
        if(Time.time > lastAttackTime+attackCooldown)
        {
            lastAttackTime = Time.time;
            PlayerBehaviourScript.Instance.DamagePlayer(attackDamage);
        }

        if(Vector2.Distance(transform.position, player.position) > attackRange)
        {
            currentState = zombieState.chasing;
        }
    }
}
