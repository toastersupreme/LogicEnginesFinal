using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[CreateAssetMenu]
public class DeadState : AState<NPCRacer>
{
    public override void OnEnter(NPCRacer entity)
    {
        entity.agent.isStopped = true;
        entity.transform.tag = "Untagged";
        entity.Announce("I AM DEAD", "Red");
    }

    public override void OnExecute(NPCRacer entity)
    {
        entity.Announce("still dead", "Red");
    }
    public override void OnExit(NPCRacer entity)
    {
        
        entity.Announce("undying?", "Red");
    }
}
