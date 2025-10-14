using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3.0f; 
    public GameObject explosionEffect;
    public float explosionRadius = 2.0f;
    public float explosionDamage = 50.0f;

    public string[] damageTags = { "Player", "Enemy" };

    private void Start()
    {
        Invoke("Explode", delay);
    }
    // Call this method to trigger the explosion
    void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        // Detect all colliders in the explosion radius for bomb
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hitCollider in hitColliders)
        {
            foreach (string tag in damageTags)
            {
                if (hitCollider.CompareTag(tag))
                {
                    Debug.Log("Bomb exploded and hit: " + hitCollider.name);
                }
            }
        }
        Destroy(gameObject);

    }
    
}

