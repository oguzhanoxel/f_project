using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    public LevelManager levelManager;
    public EnemyManager enemyManager;
    
    void Start()
    {
        Instance = this;
        levelManager.RestartLevel();
    }

    public void LevelCompleted()
    {
       enemyManager.StopEnemies();
    }
}
