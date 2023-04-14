using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatroler : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform PatrolPointParent;

    private Transform[] targets;
    private int targetIndex = 0;
   
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        targets = PatrolPointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathStatus.Equals(NavMeshPathStatus.PathComplete) || agent.isStopped)
        {
            agent.SetDestination(targets[targetIndex].position);
            targetIndex++;
            if (targetIndex >= targets.Length)
                targetIndex = 0;
        }
    }
}
