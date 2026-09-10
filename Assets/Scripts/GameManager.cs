using UnityEngine;
using GoogleMobileAds.Client;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int score = 0;
    [SerializeField] private int highScore = 0;
    public int Lives = 3;
    
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize Google Mobile Ads SDK
        MobileAds.Initialize(initStatus => { });
        LoadHighScore();
        RequestBannerAd();
    }

    public void AddScore(int points)
    {
        score += points;
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    public int GetScore() => score;
    public int GetHighScore() => highScore;

    private void RequestBannerAd()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Banner Ad Unit ID
        #endif
        #if UNITY_IPHONE
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Banner Ad Unit ID
        #endif

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }

    public void RequestInterstitialAd()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Interstitial Ad Unit ID
        #endif
        #if UNITY_IPHONE
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Interstitial Ad Unit ID
        #endif

        InterstitialAd.Load(adUnitId, new AdRequest(), 
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.Log("Interstitial ad failed to load: " + error);
                    return;
                }

                interstitialAd = ad;
                if (interstitialAd != null)
                {
                    interstitialAd.Show();
                }
            });
    }

    public void RequestRewardedAd(System.Action onRewardEarned)
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Rewarded Ad Unit ID
        #endif
        #if UNITY_IPHONE
            string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // Replace with your AdMob Rewarded Ad Unit ID
        #endif

        RewardedAd.Load(adUnitId, new AdRequest(),
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.Log("Rewarded ad failed to load: " + error);
                    return;
                }

                rewardedAd = ad;
                rewardedAd.Show((Reward reward) =>
                {
                    onRewardEarned?.Invoke();
                });
            });
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ResetGame()
    {
        score = 0;
        Lives = 3;
    }
}
