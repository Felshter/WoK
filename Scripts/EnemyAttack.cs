using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackInterval = 3.0f; 
    public int attackDamage = 5; 
    public GameObject playerObject;
    private PlayerHealth playerHealth;

    private float nextAttackTime = 0f; 

    public bool isAttack = false;
    public float attackRange = 1.0f; 

    void Start()
    {
        if (playerObject != null)
        {
            playerHealth = playerObject.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("Player object does not have a PlayerHealth component.");
            }
        }
        else
        {
            Debug.LogError("Player object is not assigned.");
        }
    }

    private void Update()
    {
        if (isAttack && nextAttackTime >= attackInterval)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerObject.transform.position);
            if (distanceToPlayer <= attackRange)
            {
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);
                }
                nextAttackTime = 0; 
            }
        }
        nextAttackTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = false;
        }
    }
}
