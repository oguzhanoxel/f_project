using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;
    public List<Enemy> Enemies;
    
    void Start()
    {
        Instance = this;    
    }

    public void LevelCompleted()
    {
        foreach (var enemy in Enemies) enemy.SetMoveSpeed(0);
    }
}
