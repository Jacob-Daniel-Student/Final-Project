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
    public static void LoadInputScene(int input) 
    {
        SceneManager.LoadScene(input);
    }
    public static void LoadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void Quit()
    {
        Application.Quit();
    }
}