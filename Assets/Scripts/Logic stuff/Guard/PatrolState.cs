using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class PatrolState : AState<GuardPatroler>
{
    public override void OnEnter(GuardPatroler entity)
    {
        entity.agent = entity.GetComponent<NavMeshAgent>();
        entity.patrolPoints = entity.PatrolPointParent.GetComponentsInChildren<Transform>();
        var closetPoint = entity.patrolPoints[entity.patrolIndex];
        var closetPointIndex = entity.patrolIndex;
        int i = 1;
        foreach (Transform t in entity.patrolPoints)
        {
            if (t != entity.patrolPoints[0])
            {
                var TD = Vector3.Distance(entity.transform.position, t.position);
                if (Vector3.Distance(entity.transform.position, closetPoint.position) > TD)
                {
                    closetPoint = t;
                    closetPointIndex = i;
                }
                i++;
            }
        }

        entity.agent.SetDestination(closetPoint.position);
        entity.patrolIndex = closetPointIndex;
        entity.agent.isStopped = false;
        entity.Announce("Patrol Started", "Blue");
    }

    public override void OnExecute(GuardPatroler entity)
    { 
        float distanceToPlayer = Vector3.Distance(entity.transform.position, entity.target.position);
        float distanceToTarget = Vector3.Distance(entity.transform.position, entity.agent.destination);
        if (distanceToPlayer < entity.aggroDistance && (entity.target.CompareTag("Racer") || entity.CompareTag("Player")))
        {
            entity.agent.SetDestination(entity.target.position);
        }
        else        
        {
            if (distanceToTarget < 2)
            {
                entity.patrolIndex++;
                entity.PatrolPoint++;
                if (entity.patrolIndex >= entity.patrolPoints.Length)
                {
                    entity.patrolIndex = 1;
                }
                entity.agent.isStopped = false;
                entity.agent.SetDestination(entity.patrolPoints[entity.patrolIndex].position);
                if (GuardPatroler.NumberOfPatrolPointsBeforeIdling < entity.PatrolPoint)
                {
                    entity.ChangeState(AIStates.Idle);
                    entity.Announce("Idle Time", "Blue");
                }
            }
        }
    }

    public override void OnExit(GuardPatroler entity)
    {
        entity.Announce("Exiting Patrol", "Blue");
    }
}
