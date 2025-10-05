using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public enum zombieState
    {
        idle,
        chasing,
        damage,
    }
    public float speed = 2.0f;
    public int health = 100;

    protected Transform player;
    protected zombieState currentState = zombieState.idle;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameManager.Instance.RegisterEnemy(this);
    }

    protected virtual void Update()
    {
        switch (currentState)
        {
            case zombieState.idle:
                lookForPlayer();
                break;
            case zombieState.chasing:
                MoveTowardsPlayer();
                break;
            case zombieState.damage:
                attackPlayer();
                break;

        }
    }

    protected virtual void lookForPlayer()
    {
        if (player != null)
        {
            currentState = zombieState.chasing;
        }
    }
    protected virtual void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    protected virtual void attackPlayer()
    {
        // attack logic here will be overrideden
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }
}
