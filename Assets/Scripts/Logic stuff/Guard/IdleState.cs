using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]

public class IdleState : AState<GuardPatroler>
{
    public override void OnEnter(GuardPatroler entity)
    {
        entity.Announce("Entered Idle", "Yellow");
        entity.agent.isStopped = true;
        entity.PatrolPoint = 0;
        entity.StartCoroutine(Countdown(GuardPatroler.idleLengthInSeconds,entity));
    }

    public override void OnExecute(GuardPatroler entity)
    {
        entity.Announce("Idle", "Yellow");
        
        float distanceToPlayer = Vector3.Distance(entity.transform.position, entity.target.position);
        if (distanceToPlayer < entity.aggroDistance)
        {            
            entity.agent.isStopped = false;
            entity.agent.SetDestination(entity.target.position);
            entity.ChangeState(AIStates.Patrol);
        }
       
    }

    public override void OnExit(GuardPatroler entity)
    {
        entity.Announce("leaving Idle", "Yellow");
    }

    IEnumerator Countdown(int seconds, GuardPatroler entity)
    {
        int counter = seconds;
        if (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        entity.ChangeState(AIStates.Patrol);
    }
}

