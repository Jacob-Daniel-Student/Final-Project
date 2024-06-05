using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    public Animator animator;
    public PlayerMovement pm;
    public PlayerMeleeAttack melee; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", pm.isRunning);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
