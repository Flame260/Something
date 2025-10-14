using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // player health
    public int playerHealth = 100;
    public int playerCurrentHealth;

    //enemy list
    public List<EnemyBase> allEnemies = new List<EnemyBase>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerCurrentHealth = playerHealth;
    }
    // damage player logic
    public void DamagePlayer(int damage)
    {
        playerCurrentHealth -= damage;
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerHealth);

        if(playerCurrentHealth <= 0)
        {
            playerDie();
        }
    }

    public void Healplayer(int healAmount)
    {
        // heal system maybe later
    }

    private void playerDie()
    {
        // handle death of palyer maybe add animation or something
    }
    // damage enemy logic
    private void damageEnemy(EnemyBase enemy, int damge)
    {
        if(enemy != null)
        {
            enemy.TakeDamage(damge);
        }
    }
    // enemy registration system
    public void RegisterEnemy(EnemyBase enemy)
    {
        if(!allEnemies.Contains(enemy))
        {
            allEnemies.Add(enemy);
        }
    }
    // enemy unregistration system
    public void UnregisterEnemy(EnemyBase enemy)
    {
        if(allEnemies.Contains(enemy))
        {
            allEnemies.Remove(enemy);
        }
    }

}
