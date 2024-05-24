using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer > 0f) 
        {
            cooldownTimer -= Time.deltaTime;
        }
        if(!isDashing && cooldownTimer <= 0) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                StartDash();
            }
        }
        if (isDashing) 
        {
            dashTimer += Time.deltaTime;
            if(dashTimer >= dashDuration) 
            {
                StopDash();
            }
        }
    }

    private void StopDash()
    {
        isDashing = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    private void StartDash()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isDashing = true;
        dashTimer = 0f;
        cooldownTimer = dashCooldown;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(horizontalInput, verticalInput) * dashSpeed;
        
    }
}
