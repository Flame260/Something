using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
