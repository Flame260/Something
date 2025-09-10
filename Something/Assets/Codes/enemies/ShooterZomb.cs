using UnityEngine;

public class ShooterZomb : EnemyBase
{
    public float shootRange = 5.0f;
    public GameObject enemyBullet;
    public Transform shootPoint;
    public float shootCooldown = 2.0f;
    private float lastShootTime;

    protected override void Update()
    {
        if (player != null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > shootRange)
        {
            MoveTowardsPlayer();
        }

        if (Time.time >= lastShootTime + shootCooldown)
        {
            shoot();
            lastShootTime = Time.time;
        }

    }
    void shoot()
    {
        Instantiate(enemyBullet, shootPoint.position, Quaternion.identity);
    }
}
