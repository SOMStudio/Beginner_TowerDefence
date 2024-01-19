using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int taskScore = 3;
    [SerializeField] private int health;
    
    public void AddScore(int addScore)
    {
        score += addScore;
    }

    public int GetScore()
    {
        return score;
    }
    
    public int GetTaskScore()
    {
        return taskScore;
    }
    
    public void AddHealth(int addHealth)
    {
        health += addHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
