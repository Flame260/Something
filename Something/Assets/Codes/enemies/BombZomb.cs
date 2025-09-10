using UnityEngine;

public class BombZomb : EnemyBase
{
    public float explosionRadius = 2.0f;
    public float explosionDamage = 50.0f;
    public GameObject explosionEffect;

    public GameObject bombdrop;

    public string[] damageTags = { "Player", "Enemy" };

    private bool explosion = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            explosion = true;
            explode();
        }
    }

    void explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hitCollider in hitColliders)
        {
            foreach (string tag in damageTags)
            {
                if (hitCollider.CompareTag(tag))
                {
                    Debug.Log("Bomb");
                }
            }
        }

        Die();
    }

    protected override void Die()
    {
        if (!explosion)
        {
            DropBomb();
        }
        base.Die();
    }

    void DropBomb()
    {
        Instantiate(bombdrop, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}