using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField]
    private Enemy[] enemyPrefabs;
    [SerializeField]
    private Shell shellPrefab; 
    
    public UnityEvent OnRoomClear;
    
    
    public List<Enemy> enemies = new();

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
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    Destroy(enemies[i].gameObject);
                    continue;
                }

                if (Random.value >= 0.45f)
                    Instantiate(shellPrefab, enemies[i].transform.position, Quaternion.identity);
                Destroy(enemies[i].gameObject);
                enemies.RemoveAt(i);
            }
        }
        if(enemies.Count == 0)
            OnRoomClear.Invoke();
    }
    
    // pass the spawners position here and spawn the enemy
    public void SpawnEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(enemyPrefabs[Random.value >= 0.5 ? 0 : 1], position, Quaternion.identity, transform);
        enemy.InitLastShot();
        enemies.Add(enemy);
    }
}

interface IEnemy
{
    public void UpdateEnemy();
}
