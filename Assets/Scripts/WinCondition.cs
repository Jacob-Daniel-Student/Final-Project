using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
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
        if (enemies <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
