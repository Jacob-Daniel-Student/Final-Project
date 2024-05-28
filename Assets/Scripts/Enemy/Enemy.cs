using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    public float distanceBetween = 1f;
    public int health;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - player.transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(distance < distanceBetween) 
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }
    public void TakeDamage(int damage) 
    {
        health -= damage;
        Debug.Log("Damage Taken");
    }
    public void Death() 
    {
        if(health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
