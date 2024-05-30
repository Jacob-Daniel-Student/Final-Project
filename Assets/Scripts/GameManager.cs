using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    private bool win = false;

    void Start()
    {
        CountActiveEnemies();
        Debug.Log(CountActiveEnemies());
    }
    private void Update()
    {
        if(CountActiveEnemies() <= 0) 
        {
            win = true;
        }
    }

    // Method to add an enemy to the list
    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    // Method to remove an enemy from the list
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        CheckEnemyCount();
    }

    // Method to check if there are no more enemies
    private void CheckEnemyCount()
    {
        if (CountActiveEnemies() <= 0)
        {
            Debug.Log("All enemies defeated!");
            // Do something when all enemies are defeated, such as triggering the next level or victory screen.
        }
    }
    int CountActiveEnemies()
    {
        // Count the number of active enemies in the scene
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}