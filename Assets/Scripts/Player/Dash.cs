using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PlayerMovement
{
    public float dashTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dashTime -= Time.deltaTime;
            if (dashTime > 0.0f)
            {
                movespeed = 15f;
            }
        }
    }
}
