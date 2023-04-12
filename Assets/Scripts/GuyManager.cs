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


    // Update is called once per frame
    void Update()
    {
        lifeText.text = lifeCount.ToString();
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
