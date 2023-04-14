using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        
        //if player enters the field, pop up win text
        if (other.tag == "Player")
        {
            gameManager.PlayerWon.Invoke();
        }
    }
    
}
