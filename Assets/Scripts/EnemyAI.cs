using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float ChaseRange = 6;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();     
    }

    void FixedUpdate()
    {
        distanceToTarget = Vector3.Distance(Target.position, transform.position);
        
        if(distanceToTarget <= ChaseRange)
        {
            navMeshAgent.SetDestination(Target.position);
            isChasing = true;
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);
            isChasing = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        _ = isChasing ? Gizmos.color = Color.red : Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, ChaseRange);
        Gizmos.DrawLine(transform.position, Target.position);
    }
}
