using UnityEngine;

public class BombZomb : EnemyBase
{
    public float explosionRadius = 2.0f;
    public int explosionDamage = 50;
    public GameObject explosionEffect;

    public GameObject bombdrop;

    public string[] damageTags = { "Player", "Enemy" };

    private bool explosion = false;


    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
        if (Vector2.Distance(transform.position, player.position) <= 1.2f)
        {
            currentState = zombieState.damage;
        }
    }

    protected override void attackPlayer()
    {
        if(!explosion)
        {
            explode();
        }
    }

    void explode()
    {
        explosion = true;

        if(explosionEffect != null)
        {
            GameObject effect = Instantiate(explosionEffect,transform.position, Quaternion.identity);
            Destroy(effect, 3f);
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach(Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                GameManager.Instance.DamagePlayer(explosionDamage);
            }

            EnemyBase enemy = hit.GetComponent<EnemyBase>();
            if (enemy != null && enemy != this)
            {
                enemy.TakeDamage(explosionDamage);
            }
        }

        Die();
    }

    protected override void Die()
    {
        if (!explosion && bombdrop != null)
        {
            Instantiate(bombdrop, transform.position, Quaternion.identity);
        }
        base.Die();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}