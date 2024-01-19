using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int taskScore = 3;
    [SerializeField] private int health;

    [Header("Enemies")]
    [SerializeField] private List<EnemyManager> enemies;

    [Header("Guns")]
    [SerializeField] private GunManager[] guns;

    [Header("Trajectory")]
    [SerializeField] private Transform[] points;
    
    [Header("Components")]
    [SerializeField] private SpawnComponent spawnComponent;
    [SerializeField] private TimerComponent timerComponent;

    [Header("Events")]
    public UnityEvent<EnemyManager> addEnemyEvent;
    public UnityEvent<EnemyManager> removeEnemyEvent;

    private void Awake()
    {
        if (spawnComponent == null) spawnComponent = GetComponent<SpawnComponent>();
        if (timerComponent == null) timerComponent = GetComponent<TimerComponent>();
    }

    private void Start()
    {
        spawnComponent.spawnObjectEvent.AddListener(AddEnemy);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }

    public int GetScore()
    {
        return score;
    }
    
    public void AddHealth(int addHealth)
    {
        health += addHealth;
    }

    public int GetHealth()
    {
        return health;
    }
    
    public int GetTaskScore()
    {
        return taskScore;
    }

    private void AddEnemy(GameObject enemy)
    {
        var enemyManager = enemy.GetComponent<EnemyManager>();
        if (enemyManager != null)
        {
            enemies.Add(enemyManager);
            enemyManager.SetPoints(points);
            
            enemyManager.reachFinalPointEvent.AddListener(ReachFinalPointEnemy);
            enemyManager.deathEvent.AddListener(RemoveEnemy);
            
            addEnemyEvent?.Invoke(enemyManager);
        }
    }

    private void ReachFinalPointEnemy(EnemyManager enemy)
    {
        AddHealth(-1);
        
        RemoveEnemy(enemy);
    }
    
    private void RemoveEnemy(EnemyManager enemy)
    {
        removeEnemyEvent?.Invoke(enemy);

        enemies.Remove(enemy);
    }
    
    private Transform FindNearestEnemy(GunManager gun)
    {
        var enemyList = enemies;
        int enemyCount = enemyList.Count;
        int numNearest = -1;
        float distNearest = 100;
        for (int i = 0; i < enemyCount; i++)
        {
            if (enemyList[i].health <= 0) continue;
            
            var vectorToEnemy = gun.GetVectorToTarget(enemyList[i].transform);
            var distToEnemy = vectorToEnemy.magnitude;
            if (distToEnemy < distNearest)
            {
                numNearest = i;
                distNearest = distToEnemy;
            }
        }

        return numNearest == -1 ? null : enemyList[numNearest].transform;
    }

    public void GunNeedEnemy(GunManager gun)
    {
        var resulEnemy = FindNearestEnemy(gun);
        
        if (resulEnemy != null) gun.SetTarget(resulEnemy);
    }

    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
