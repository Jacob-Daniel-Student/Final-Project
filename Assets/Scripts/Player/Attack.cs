using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float attackCooldown = 1f;
    public float startAttackTime = 2f;
    public bool isAttacking = false;

    public Transform attackPos;
    public LayerMask whatIsEnimes; 
    public float attackRange;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] enimesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnimes);
                for(int i = 0; i < enimesToDamage.Length; i++)
                {
                    enimesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            attackCooldown = startAttackTime;
        }
        else 
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
