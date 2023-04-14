using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCAggroChaser : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform PatrolPointParent;
    private Transform[] patrolPoints;
    private int patrolIndex = 1;

    public Transform target;
    public float aggroDistance;

    public bool followPatrol;
    public void StartPatroling()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPoints = PatrolPointParent.GetComponentsInChildren<Transform>();
        var closetPoint = patrolPoints[patrolIndex];
        var closetPointIndex = patrolIndex;
        int i = 1;
        foreach (Transform t in patrolPoints)
        {
            if (t != patrolPoints[0])
            {
                var TD = Vector3.Distance(transform.position, t.position);
                if (Vector3.Distance(transform.position, closetPoint.position) > TD)
                {
                    closetPoint = t;
                    closetPointIndex = i;
                }
                i++;
            }
        }

        agent.SetDestination(closetPoint.position);
        patrolIndex = closetPointIndex;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (followPatrol)
        { 

        }
        
    }
}
