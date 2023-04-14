using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdSummoner : MonoBehaviour
{
    public InterstitialAdsButton interstitialAdsButton;
    // Start is called before the first frame update
    void Start()
    {
        interstitialAdsButton.LoadAd();
    }

    
}
