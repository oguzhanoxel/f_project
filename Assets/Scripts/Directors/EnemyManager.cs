using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    [SerializeField] public Enemy enemyPrefab;

    public void RestartEnemies()
    {
        StartCoroutine(RestartEnemiesCoroutine());
    }
    
    private IEnumerator RestartEnemiesCoroutine()
    {
        DeleteEnemies();
        yield return new WaitForEndOfFrame();
        GenerateEnemies();
    }
    
    public void StopEnemies()
    {
        foreach (var enemy in enemies) enemy.Stop();
    }

    private void GenerateEnemies()
    {
        var enemyCount = Random.Range(3, 10);
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            var posX = Random.Range(-10f, 10f);
            var posZ = Random.Range(-8f, 8f);
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
