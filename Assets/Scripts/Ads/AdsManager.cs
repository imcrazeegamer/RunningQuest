using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] static string _androidGameId = "4656643";
    [SerializeField] static string _iOSGameId = "4656642";
    public static AdsManager instance = null;
#if UNITY_IOS
       string _gameId = _iOSGameId;
#elif UNITY_ANDROID
       string _gameId = _androidGameId;
#else
       string _gameId = "";
#endif

    [SerializeField] GameObject adPanel;
    [SerializeField] bool testMode = true;



    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (_gameId == "")
        {
            Destroy(adPanel);
            Destroy(this);
            Debug.Log("No Ad ID");
        }
        else
        {
            Debug.Log("Ad Manager Init Please!");
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(_gameId, testMode, this);
            
        }
        
    }
    
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialized");
        //foreach (RewardAds item in FindObjectsOfType<RewardAds>())
        //{
        //    item.LoadAd();
        //}
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Error {error} - {message}");
    }
}
