using UnityEngine;

public class ShooterZomb : EnemyBase
{
    public float shootRange = 10f;
    public GameObject enemyBullet;
    public Transform shootPoint;
    public float shootCooldown = 2.0f;
    private float lastShootTime;

    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();

        if(Vector2.Distance(transform.position, player.position) <= shootRange)
        {
            currentState = zombieState.damage;
        }
    }

    protected override void attackPlayer()
    {
        if (Time.time >= lastShootTime + shootCooldown)
        {
            lastShootTime = Time.time;

            if (enemyBullet != null && shootPoint != null)
            {
                GameObject bullet = Instantiate(enemyBullet, shootPoint.position, Quaternion.identity);
                EnemyBullet b = bullet.GetComponent<EnemyBullet>();
                if (b != null)
                {
                    Vector2 dir = (player.position - shootPoint.position).normalized;
                    b.SetDirection(dir);
                }
            }
        }

        if (Vector3.Distance(transform.position, player.position) > shootRange)
        {
            currentState = zombieState.chasing;
        }
    }
}

