using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class GuardPatroler : BaseAIEntity
{
    public const int idleLengthInSeconds = 5;
    public const int NumberOfPatrolPointsBeforeIdling = 6;

    

    public int PatrolPoint = 0;

    //AggroChaser
    public NavMeshAgent agent;

    public Transform PatrolPointParent;
    public Transform[] patrolPoints;
    public int patrolIndex = 1;

    public Transform target;
    public float aggroDistance;

    public bool followPatrol;





    public AState<GuardPatroler> currentState;

    public List<AState<GuardPatroler>> stateMachine = new List<AState<GuardPatroler>>();

    [SerializeField] private float AITickInSeconds;
    private void Awake()
    {
        ID = sNextValidID;
    }

    private void Start()
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

        ChangeState(AIStates.Patrol);

        StartCoroutine(Tick());
    }
    public override IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(AITickInSeconds);
            
            currentState?.OnExecute(this);
        }
    }
    public void ChangeState(AIStates thisState)
    {
        AState<GuardPatroler> newState = stateMachine.Find(s => s.StateType == thisState);

        Assert.IsNotNull(newState, "GuardPatroler::ChangeState:: newState is null");

        StartCoroutine(Transition(newState));
    }
    private IEnumerator Transition(AState<GuardPatroler> state)
    {
        yield return new WaitForEndOfFrame();

        currentState?.OnExit(this);
        currentState = state;
        currentState.OnEnter(this);
    }
    public void Announce(string message, string color = "white")
    {
        Debug.Log($"<color={color}>guard:{ID} {message}</color>");
    }
}
