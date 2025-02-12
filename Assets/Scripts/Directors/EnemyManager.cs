using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    [SerializeField] public Enemy enemyPrefab;
    [SerializeField] public int enemyCount = 3;

    public void RestartEnemies()
    {
        DeleteEnemies();
        GenerateEnemies();
    }
    
    public void StopEnemies()
    {
        foreach (var enemy in enemies) enemy.SetMoveSpeed(0);
    }

    private void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            var posX = Random.Range(i-4f, 4f);
            var posZ = Random.Range(-4f, 4f);
            enemy.transform.position = new Vector3(posX, 0.6f, posZ);
            enemies.Add(enemy);
        }
    }

    private void DeleteEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();
    }
}
