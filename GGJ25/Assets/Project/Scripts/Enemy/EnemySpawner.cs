using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField]
    private Enemy enemyPrefab;
    
    List<Enemy> enemies = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void UpdateEnemySpawner()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            enemies[i].UpdateEnemy();

            if (enemies[i].shouldDie)
            {
                Destroy(enemies[i].gameObject);
                enemies.RemoveAt(i);
            }
        }
    }
    
    // pass the spawners position here and spawn the enemy
    public void SpawnEnemy(Vector3 position)
    {
        enemies.Add(Instantiate(enemyPrefab, position, Quaternion.identity, transform));
    }
}

interface IEnemy
{
    public void UpdateEnemy();
}
