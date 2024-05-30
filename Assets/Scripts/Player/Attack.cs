using UnityEngine;
using UnityEngine.UI;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Transform attackPoint; // The point from which the attack will be performed
    public LayerMask enemyLayer; // The layer containing the enemies
    public float attackRange = 1f; // The range of the attack
    public float attackRate = 2f; // The rate at which the attack can be performed (attacks per second)
    public float attackCooldown = 0.5f; // The cooldown between attacks

    private float nextAttackTime = 0f; // The time when the next attack can be performed

    void Update()
    {
        // Aim the attack towards the mouse position
        AimAttack();

        // Check for input to perform the attack
        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttackTime)
        {
            PerformAttack();
            nextAttackTime = Time.time + 1f / attackRate; // Set the time when the next attack can be performed
        }
    }

    void AimAttack()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate the direction from the attack point to the mouse position
        Vector3 direction = (mousePosition - attackPoint.position).normalized;

        // Rotate the attack point to face the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void PerformAttack()
    {
        // Detect enemies in the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage each enemy hit
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Attacked " + enemy.name); // Replace this with your attack logic
            enemy.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    // Visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
