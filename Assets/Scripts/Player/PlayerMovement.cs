using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10f;
    private Rigidbody2D rb;
    public bool isRunning = false; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 boxd = new Vector2(horizontalInput, verticalInput);
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * movespeed * Time.deltaTime;
        transform.Translate(movement);
        if (horizontalInput == 0 && verticalInput == 0)
        {
            isRunning = false;
        }
        else 
        {
            isRunning = true;
        }
    }
}



