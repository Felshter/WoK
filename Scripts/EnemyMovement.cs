using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; 
    public float speed = 2.0f; 
    public float attackRange = 1.0f; 
    public float sightRange = 5.0f; 
    public LayerMask obstacleMask; 

    private Animator anim; 
    private bool Runninggoblin = false; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, sightRange, obstacleMask);

        Debug.DrawRay(transform.position, player.position - transform.position, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }

            Runninggoblin = true;
        }
        else
        {
            Runninggoblin = false;
        }

        anim.SetBool("Runninggoblin", Runninggoblin);
    }

    void AttackPlayer()
    {
        Debug.Log("Attacking Player!");
    }
}
