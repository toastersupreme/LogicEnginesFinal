using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuyManager : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public MeshRenderer guy;
    public Material paidMaterial;
    public Material adMaterial;
    
    public TextMeshProUGUI lifeText;
    public GameObject startButton;
    public TextMeshProUGUI halt;
   

    // Update is called once per frame
    void Update()
    {
        lifeText.text = playerInfo.playerLives.ToString();
        if (playerInfo.playerLives <= 0)
        {
            startButton.SetActive(false);
            halt.text = "You need lives to play!";
        }
        else
        {
            startButton.SetActive(true);
            halt.text = "";
        }
    }

    public void AdSkin()
    {
        guy.material = adMaterial;
        playerInfo.guyMat = guy.material;
    }

    public void BoughtSkin()
    {
        guy.material = paidMaterial;
        playerInfo.guyMat = guy.material;
    }

    public void BoughtLives()
    {
        playerInfo.playerLives += 5;
    }

    public void DoNothing()
    {

    }

    
}
