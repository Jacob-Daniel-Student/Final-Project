using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public Text enemiesRemaning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountActiveEnemies();
    }
    public void CountActiveEnemies()
    {
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesRemaning.text = "Enemies Remaning: " + enemies;
        if (enemies <= 0)
        {
            GameManager.LoadNextScene();
        }
        
    }
}
