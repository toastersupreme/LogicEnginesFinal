using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAgroTrigger : MonoBehaviour
{
    public Swarmer Swarm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Racer"))
        {
            Swarm.target = other.transform;
        }
    }
}
