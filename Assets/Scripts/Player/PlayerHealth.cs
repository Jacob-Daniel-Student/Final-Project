using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            GameObject.FindGameObjectWithTag("Health").gameObject.SetActive(false);
            if(health <= 0)
            {
                GameManager.LoadInputScene(5);
            }
        }
        
    }
}
