using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    public GameObject GoalPoint;
    public void Start()
    {
        GoalPoint.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoalPoint.SetActive(true);
        }
    }

}
