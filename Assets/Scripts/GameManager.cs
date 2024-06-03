using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance


    private void Awake()
    {
        if(instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    int CountActiveEnemies()
    {
        // Count the number of active enemies in the scene
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    public void LoadInputScene(int input) 
    {
        SceneManager.LoadScene(input);
    }
}