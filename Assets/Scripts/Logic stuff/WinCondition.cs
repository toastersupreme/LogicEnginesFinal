using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        
        //if player enters the field, pop up win text
        if (other.tag == "Player")
        {
            GameManager.Instance.PlayerWon.Invoke();
        }
    }
    
}
