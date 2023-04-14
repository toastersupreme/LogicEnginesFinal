using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WobbleState : AState<Swarmer>
{
    public override void OnEnter(Swarmer entity)
    {
        entity.Announce("Wobble Time");
    }

    public override void OnExecute(Swarmer entity)
    {
        Vector3 pos = entity.transform.position;
        entity.agent.SetDestination(new Vector3(pos.x + Random.Range(-3f,3f), pos.y , pos.z + Random.Range(-3f, 3f)));
        var swarmers = entity.gameManager.Swarmers;
        int randomSwarmer = Random.Range(0, swarmers.Count - 1);
        if (Vector3.Distance(entity.transform.position, swarmers[randomSwarmer].position) >= 1f)
        {
            entity.ChangeState(AIStates.GroupUp);
        }

    }
    public override void OnExit(Swarmer entity)
    {
        entity.Announce("Wobble over");
    }
}
