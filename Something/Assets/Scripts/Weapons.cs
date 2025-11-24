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

    [Header("OffSet")]
    public Vector2 localPos;
    public quaternion localRot;
    public Vector2 localSca;

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

    void Shoot()
    {
        if (!canShoot) return;
        curAmmo -= 1;
    }

    void Swing()
    {

    }

    //Eqiup on PickUp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.SetParent(collision.transform);
            transform.localPosition = localPos;
            transform.localRotation = localRot;
            transform.localScale = localSca;
        }
    }
}
