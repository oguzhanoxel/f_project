using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    public List<Enemy> enemies;

    public void StopEnemies()
    {
        foreach (var enemy in enemies) enemy.SetMoveSpeed(0);
    }
}
