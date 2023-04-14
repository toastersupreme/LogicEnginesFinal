using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCondition : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //if player enters field reset the scene
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerCaught.Invoke();
        }
    }
}
