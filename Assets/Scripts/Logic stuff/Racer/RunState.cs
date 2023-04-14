using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu]
public class RunState : AState<NPCRacer>
{
    public override void OnEnter(NPCRacer entity)
    {
        entity.agent.isStopped = false;
        entity.agent.SetDestination(entity.target.position);
        entity.Announce("Run Started", "Orange");
    }

    public override void OnExecute(NPCRacer entity)
    {
        entity.Announce("Running", "Orange");
        if(Physics.SphereCast(entity.transform.position, 3f, entity.transform.forward, out RaycastHit hit))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                entity.StateMachine.ChangeState(AIStates.Wait);
            }
        }
    }
    public override void OnExit(NPCRacer entity)
    {
        entity.Announce("Exiting Run", "Orange");
    }
}
