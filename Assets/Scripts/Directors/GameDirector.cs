using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    public LevelManager levelManager;
    public EnemyManager enemyManager;
    
    void Start()
    {
        Instance = this;
        Restart();
    }

    private void Restart()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemies();
    }

    public void LevelCompleted()
    {
       enemyManager.StopEnemies();
    }
}
