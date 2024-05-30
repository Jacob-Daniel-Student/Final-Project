using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp = 3;
    private Rigidbody2D rb;
    public int enemyCount = 16; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0) 
        {
            Destroy(gameObject);
            enemyCount--;
        }
    }
    public void TakeDamage(int damageDone)
    {
        hp -= damageDone;
    }
    private void CheckIfEnimesDefeated() 
    {
        if(enemyCount <= 0) 
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
