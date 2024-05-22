using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10f;
    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Attack();
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 boxd = new Vector2(horizontalInput, verticalInput);
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * movespeed * Time.deltaTime;
        transform.Translate(movement);

    }
    void Attack() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput > 0 ||  verticalInput > 0) 
        {
          Instantiate(boxCollider, new Vector3(horizontalInput, verticalInput) + transform.position, Quaternion.identity);
        }
        Instantiate(boxCollider, new Vector3(horizontalInput, verticalInput + 1) + transform.position, Quaternion.identity);
    }
}
