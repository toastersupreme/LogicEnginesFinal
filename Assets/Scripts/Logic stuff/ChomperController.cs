using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)),
    RequireComponent(typeof(Animator))]

public class ChomperController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                agent.SetDestination(hit.point);
            }
        }

        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
