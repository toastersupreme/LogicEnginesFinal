using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class NPCRacer : BaseAIEntity
{
    
    
    public NavMeshAgent agent;

    public Transform target;

    public AState<NPCRacer> currentState;

    [SerializeField] private StateMachine<NPCRacer> stateMachine;
    public StateMachine<NPCRacer> StateMachine { get { return stateMachine; } }

    [SerializeField] private float AITickInSeconds;
    private void Awake()
    {

        ID = sNextValidID;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StateMachine.SetOwner(this);
        StateMachine.ChangeState(AIStates.Run);

        StartCoroutine(Tick());
    }
    public override IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(AITickInSeconds);
            StateMachine.Update();
        }
    }
    private IEnumerator Transition(AState<NPCRacer> state)
    {
        yield return new WaitForEndOfFrame();

        currentState?.OnExit(this);
        currentState = state;
        currentState.OnEnter(this);
    }
    public void Announce(string message, string color = "white")
    {
        Debug.Log($"<color={color}>Racer:{ID} {message}</color>");
    }
}
