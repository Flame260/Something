using Unity.Mathematics;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject player;

    [Header("Base Settings")]
    public float damage;
    public float atkSpeed;
    public bool melee;
    public bool range;

    [Header("Range Settings")]
    public int maxAmmo;
    public int curAmmo;
    public bool canShoot;
    public float fireRate;

    [Header("OffSet")]
    public Vector2 localPos;
    public quaternion localRot;
    public Vector2 localSca;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileForce;

    private void Start()
    {
        if (range)
        {
            curAmmo = maxAmmo;
            canShoot = true;
        }
    }

    public void Update()
    {
        
    }

    public void Attack()
    {
        if (range)
        {
            Shoot();
        }
        if (melee)
        {
            Swing();
        }
    }

    public void Shoot()
    {
        if (!canShoot) return;
        curAmmo -= 1;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
        Destroy(projectile, 4f);
    }

    void Swing()
    {

    }
}
