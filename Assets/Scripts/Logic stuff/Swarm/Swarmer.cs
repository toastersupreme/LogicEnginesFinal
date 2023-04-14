using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class Swarmer : BaseAIEntity
{
    public GameManager gameManager;
    
    public const int idleLengthInSeconds = 5;
    public const int NumberOfPatrolPointsBeforeIdling = 6;


    //AggroChaser
    public NavMeshAgent agent;

  
    public Transform target;
    public float aggroDistance;

    public AState<Swarmer> currentState;

    public List<AState<Swarmer>> stateMachine = new List<AState<Swarmer>>();

    [SerializeField] private float AITickInSeconds;
    private void Awake()
    {
        ID = sNextValidID;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        gameManager.Swarmers.Add(this.transform);

        ChangeState(AIStates.Wobble);

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
        AState<Swarmer> newState = stateMachine.Find(s => s.StateType == thisState);

        Assert.IsNotNull(newState, "GuardPatroler::ChangeState:: newState is null");

        StartCoroutine(Transition(newState));
    }
    private IEnumerator Transition(AState<Swarmer> state)
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
