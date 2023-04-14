using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuyManager : MonoBehaviour
{
    public MeshRenderer guy;
    public Material paidMaterial;
    public Material adMaterial;
    public int lifeCount;
    public TextMeshProUGUI lifeText;
    public GameObject startButton;
    public TextMeshProUGUI halt;


    // Update is called once per frame
    void Update()
    {
        lifeText.text = lifeCount.ToString();
        if (lifeCount <= 0)
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
    }

    public void BoughtSkin()
    {
        guy.material = paidMaterial;
    }

    public void BoughtLives()
    {
        lifeCount += 5;
    }

    public void DoNothing()
    {

    }

    
}
