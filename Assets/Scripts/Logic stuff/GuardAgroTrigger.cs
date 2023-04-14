using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAgroTrigger : MonoBehaviour
{
    public GuardPatroler GP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GP.target = other.transform;
        }
    }
}
