using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance { get; private set; }

    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //public void GemsPurchasedCustomEvent(int gemAmount)
    //{
    //    Dictionary<string, object> parameters = new Dictionary<string, object>()
    //    {
    //        { "gemAmount", gemAmount }
    //    };

    //    AnalyticsService.Instance.CustomData("boughtGems", parameters);
    //    AnalyticsService.Instance.Flush();
    //}

    public void WatchedAdsCustomEvent(string watchedAmount)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "watchedAmount", watchedAmount }
        };

        AnalyticsService.Instance.CustomData("watchedAmount", parameters);
        AnalyticsService.Instance.Flush();
    }

    public void BoughtSkinCustomEvent(int purchasedSkin)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "purchasedSkin", purchasedSkin }
        };

        AnalyticsService.Instance.CustomData("purchasedSkin", parameters);
        AnalyticsService.Instance.Flush();
    }

    public void BoughtLivesCustomEvent(int purchasedLives)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "purchasedLives", purchasedLives }
        };

        AnalyticsService.Instance.CustomData("purchasedLives", parameters);
        AnalyticsService.Instance.Flush();
    }
}
