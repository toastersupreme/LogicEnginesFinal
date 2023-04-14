using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GroupUpState : AState<Swarmer>
{
    public override void OnEnter(Swarmer entity)
    {
        entity.Announce("Where are my other swarmers");
    }

    public override void OnExecute(Swarmer entity)
    {
        entity.Announce("where is everyone");
        var swarmers = entity.gameManager.Swarmers;
        int randomSwarmer = Random.Range(0, swarmers.Count - 1);

        entity.agent.SetDestination(swarmers[randomSwarmer].position);

        if (Vector3.Distance(entity.transform.position, swarmers[randomSwarmer].position) <= 1f)
        {
            entity.ChangeState(AIStates.Wobble);
        }
    }

    public override void OnExit(Swarmer entity)
    {
        entity.Announce("i grouped up");
    }
}
