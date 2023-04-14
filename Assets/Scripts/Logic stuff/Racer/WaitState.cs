using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]

public class WaitState : AState<NPCRacer>
{
    public override void OnEnter(NPCRacer entity)
    {
        entity.Announce("Entered wait", "Yellow");
        entity.agent.isStopped = true;
    }

    public override void OnExecute(NPCRacer entity)
    {
        entity.Announce("Wait", "Blue");

        if (Physics.SphereCast(entity.transform.position,3f,entity.transform.forward, out RaycastHit hit))
        {

            entity.StateMachine.ChangeState(AIStates.Run);

        }
    }

    public override void OnExit(NPCRacer entity)
    {
        entity.Announce("leaving Wait", "Blue");
    }
}

