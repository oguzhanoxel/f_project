using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    public LevelManager levelManager;
    public EnemyManager enemyManager;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Restart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Restart();
    }

    private void Restart()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemies();
        Player.Instance.ResetPlayer();
    }

    public void LevelCompleted()
    {
       enemyManager.StopEnemies();
    }

    public void LevelFailed()
    {
        enemyManager.StopEnemies();
    }
}
