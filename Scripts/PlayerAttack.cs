using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 25; 
    public float attackRange = 0.5f; 
    public float attackCooldown = 1f; 
    public Transform attackPoint; 
    public LayerMask enemyLayers; 

    private Animator anim; 
    private bool canAttack = true; 
    private float lastAttackTime; 

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(AttackCoroutine()); 
        }
    }

    IEnumerator AttackCoroutine()
    {
        anim.SetBool("Attack", true); 
        PerformAttack(); 

        canAttack = false; 

        yield return new WaitForSeconds(attackCooldown); 

        canAttack = true; 
        anim.SetBool("Attack", false); 
    }

    void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy hit! Remaining health: " + enemyHealth.currentHealth);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
