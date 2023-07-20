using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float chaseRange = 10f;
    public float destroyRange = 2f;
    public int damageAmount = 20; // The amount of damage the enemy does to the player.

    private Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= destroyRange)
            {
                // Damage the player if the enemy is in close range
                player.GetComponent<Fox>().TakeDamage(damageAmount);
                // Destroy itself when in close range of the player
                Destroy(gameObject);
            }
        }
    }
}
