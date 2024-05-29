using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public KeyCode attackKey = KeyCode.Space; // Change this to the key you want to use for attacking
    public float attackRange = 1f; // Range of the melee attack
    public LayerMask attackLayer; // Layer mask to filter out objects that can be attacked

    private Animator animator; // Reference to the Animator component
    private bool isAttacking = false; // Flag to prevent multiple attacks

    void Start()
    {
        // Get reference to the Animator component attached to the player character
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerDirection = Input.mousePosition - transform.position;

        // Check if attack key is pressed and the player is not already attacking
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            // Trigger the attack animation
            animator.SetTrigger("Attack");

            // Call the Attack method after a short delay (you can adjust the delay as needed)
            AttackD(playerDirection);  
        }
            ResetAttack();
    }

    void AttackD(Vector3 playerDirection)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, playerDirection, attackRange, attackLayer);

        // Set isAttacking flag to true to prevent multiple attacks during the animation
        isAttacking = true;

        // Perform a raycast in the direction the player is facing to detect enemies within attack range

        // Loop through all hits and damage the enemies
        foreach (RaycastHit2D hit in hits)
        {
            // Assuming enemies have a health component, you can replace this with whatever logic you use for damaging enemies
            Health enemyHealth = hit.collider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Damage the enemy (1 damage point in this example)
            }
        }

        // Reset isAttacking flag after the attack animation duration (you can adjust the duration based on your animation)
        Invoke("ResetAttack", 0.5f);
    }

    void ResetAttack()
    {
        // Reset isAttacking flag to allow the player to attack again
        isAttacking = false;
    }
}

