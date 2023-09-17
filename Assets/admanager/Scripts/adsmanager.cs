using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class adsmanager : MonoBehaviour
{

    public static adsmanager instance { get; set; }

    //[HideInInspector] public int rewardedCoins;

    //[HideInInspector] public bool enableTestMode;
    //[HideInInspector] public string appID;
    [HideInInspector] public string bannerID;
    [HideInInspector] public AdPosition bannerPosition;
    [HideInInspector] public string interstitialID1;
    [HideInInspector] public string interstitialID2;
    [HideInInspector] public string interstitialID3;
    [HideInInspector] public string rewardedVideoAdsID1;
    [HideInInspector] public string rewardedVideoAdsID2;

    private BannerView bannerView;
    private InterstitialAd interstitial1;
    private InterstitialAd interstitial2;
    private InterstitialAd interstitial3;
    private RewardedAd rewardVideoAd1;


    private string appId;
    private string showaads;
    private string showbannerID;
    private string showinterstitial1;
    private string showinterstitial2;
    private string showinterstitial3;
    private string showrewardedVideoAdsID1;




    bool isRewardAdded;

    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        appId = AdsParameter.instance.g_app_id;

        showaads = AdsParameter.instance.showAds;

        showinterstitial1 = AdsParameter.instance.show_g_inter1;
        showinterstitial2 = AdsParameter.instance.show_g_inter2;
        showinterstitial3 = AdsParameter.instance.show_g_inter3;
        showrewardedVideoAdsID1 = AdsParameter.instance.show_g_rewarded1;



        interstitialID1 = AdsParameter.instance.g_inter1;
        //interstitialID1 = "ca-app-pub-4905629984957668/3988373909";
        interstitialID2 = AdsParameter.instance.g_inter2;
        //interstitialID2 = "ca-app-pub-4905629984957668/3988373909";
        interstitialID3 = AdsParameter.instance.g_inter3;
        //interstitialID3 = "ca-app-pub-4905629984957668/3988373909";
        rewardedVideoAdsID1 = AdsParameter.instance.g_rewarded1;

        MobileAds.Initialize(initStatus => { });
        DontDestroyOnLoad(this.gameObject);


       // bannerID = "ca-app-pub-3940256099942544/6300978111";
       // interstitialID1 = "ca-app-pub-3940256099942544/1033173712";
       // interstitialID2 = "ca-app-pub-3940256099942544/1033173712";
       // interstitialID3 = "ca-app-pub-3940256099942544/1033173712";
       // rewardedVideoAdsID1 = "ca-app-pub-3940256099942544/5224354917";//----------------------------INCREASEBALLS---------------------------------------------------------------------------------
       //// rewardedVideoAdsID2 = "ca-app-pub-3940256099942544/5224354917";//-------------------------------------------------------------------------------------------------------------


        InitializeAds();
    }
    //private void RequestBannerAd()
    //{
    //    bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);
    //    AdRequest request = new AdRequest.Builder().Build();
    //    bannerView.LoadAd(request);

    //    Debug.Log("Adsss" + showaads);

    //    if (showaads.Equals("TRUE"))
    //    {
    //        if (showbannerID.Equals("TRUE"))
    //        {

    //        }

    //    }
    //}
    ////--------------------------------------------------------------------------------------------------------------------------------------------------
    private void RequestInterstialAd1()

    {
                this.interstitial1 = new InterstitialAd(interstitialID1);

                AdRequest request = new AdRequest.Builder().Build();

                this.interstitial1.LoadAd(request);
                this.interstitial1.OnAdLoaded += HandleOnAdLoaded;
                // Called when an ad request failed to load.
                this.interstitial1.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                // Called when an ad is shown.
                this.interstitial1.OnAdOpening += HandleOnAdOpening;
                // Called when the ad is closed.
                this.interstitial1.OnAdClosed += HandleOnAdClosed;
    }
    private void RequestInterstialAd2()
    {
                this.interstitial2 = new InterstitialAd(interstitialID2);

                AdRequest request = new AdRequest.Builder().Build();

                this.interstitial2.LoadAd(request);
                this.interstitial2.OnAdLoaded += HandleOnAdLoaded;
                // Called when an ad request failed to load.
                this.interstitial2.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                // Called when an ad is shown.
                this.interstitial2.OnAdOpening += HandleOnAdOpening;
                // Called when the ad is closed.
                this.interstitial2.OnAdClosed += HandleOnAdClosed;
     
            

     
    }
    private void RequestInterstialAd3()
    {

        //if (showaads.Equals("TRUE"))
        //{
        //    if (showinterstitial3.Equals("TRUE"))
        //    {
                this.interstitial3 = new InterstitialAd(interstitialID3);
                AdRequest request = new AdRequest.Builder().Build();
                this.interstitial3.LoadAd(request);

                // Called when an ad request has successfully loaded.
                this.interstitial3.OnAdLoaded += HandleOnAdLoaded;
                // Called when an ad request failed to load.
                this.interstitial3.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                // Called when an ad is shown.
                this.interstitial3.OnAdOpening += HandleOnAdOpening;
                // Called when the ad is closed.
                this.interstitial3.OnAdClosed += HandleOnAdClosed;
        //    }
            

        //}


    }
    //------------------------------------------------------------------------------------------------------------------------------
    private void RequestRewardedVideoAd1()
    {

        //if (showaads.Equals("TRUE"))
        //{
        //    if (showrewardedVideoAdsID1.Equals("TRUE"))
        //    {
                this.rewardVideoAd1 = new RewardedAd(rewardedVideoAdsID1);

                if (rewardVideoAd1.IsLoaded())
                {

                }
                else
                {
                    isRewardAdded = false;

                    this.rewardVideoAd1.OnAdLoaded += HandleRewardedAdLoaded;
                    // Called when an ad request failed to load.
                    this.rewardVideoAd1.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
                    // Called when an ad is shown.
                    this.rewardVideoAd1.OnAdOpening += HandleRewardedAdOpening;
                    // Called rewardVideoAd an ad request failed to show.
                    this.rewardVideoAd1.OnAdFailedToShow += HandleRewardedAdFailedToShow;
                    // Called when the user should be rewarded for interacting with the ad.
                    this.rewardVideoAd1.OnUserEarnedReward += HandleUserEarnedReward;
                    // Called when the ad is closed.
                    this.rewardVideoAd1.OnAdClosed += HandleRewardedAdClosed;

                    AdRequest request = new AdRequest.Builder().Build();
                    this.rewardVideoAd1.LoadAd(request);
                }
        //    }
            

        //}
        

      
    }
    //private void RequestRewardedVideoAd2()
    //{
    //    isRewardAdded = false;

    //    this.rewardVideoAd2 = new RewardedAd(rewardedVideoAdsID2);

    //    this.rewardVideoAd2.OnAdLoaded += HandleRewardedAdLoaded;
    //    // Called when an ad request failed to load.
    //    this.rewardVideoAd2.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
    //    // Called when an ad is shown.
    //    this.rewardVideoAd2.OnAdOpening += HandleRewardedAdOpening;
    //    // Called rewardVideoAd an ad request failed to show.
    //    this.rewardVideoAd2.OnAdFailedToShow += HandleRewardedAdFailedToShow;
    //    // Called when the user should be rewarded for interacting with the ad.
    //    this.rewardVideoAd2.OnUserEarnedReward += HandleUserEarnedReward;
    //    // Called when the ad is closed.
    //    this.rewardVideoAd2.OnAdClosed += HandleRewardedAdClosed;

    //    AdRequest request = new AdRequest.Builder().Build();

    //    this.rewardVideoAd2.LoadAd(request);
    //}
    public void InitializeAds()
    {
        MobileAds.Initialize(initStatus => { });

        this.RequestInterstialAd1();
        this.RequestInterstialAd2();
        this.RequestInterstialAd3();
       // this.ShowBannerAds();

        this.RequestRewardedVideoAd1();
        // this.RequestRewardedVideoAd2();
    }
    //public void InitializeBannerAd()
    //{
    //    MobileAds.Initialize(initStatus => { });

    //    this.RequestBannerAd();
    //}
    //public void ShowBannerAds()
    //{

    //    if (showaads.Equals("TRUE"))
    //    {
    //        this.RequestBannerAd();
    //        this.bannerView.Show();
    //    }
    //    //}

    //    //this.RequestBannerAd();
    //    //    this.bannerView.Show();
    //}
    //public void DestroyBannerAdmob()
    //{
    //    this.bannerView.Destroy();
    //}
    //-------------------------------------------------------------------------player-lose--------------------------------------------------------------
    public void ShowInterstitialads1()
    {
        if (showaads.Equals("True"))
        {
            if (showinterstitial1.Equals("True"))
            {
                if (this.interstitial1.IsLoaded())
                {

                    this.interstitial1.Show();
                }
                else
                {
                    this.RequestInterstialAd1();
                }
            }
        }
        
        //}
        
    }    //--------------------------------------------------------------------------------level-complete----------------------------------------------------
    public void ShowInterstitialads2()
    {
        if (showaads.Equals("True"))
        {
            if (showinterstitial2.Equals("True"))
            {
                if (this.interstitial2.IsLoaded())
                {
                    // Debug.Log("Interstitial was loaded succesfully!");

                    this.interstitial2.Show();
                }
                else
                {
                    this.RequestInterstialAd2();
                }
            }
        }
        
    }//--------------------------------------------------------------------------------------------player go to maib menu-------------------------------------------------------
    public void ShowInterstitialads3()
    {
        if (showaads.Equals("True"))
        {
            if (showinterstitial3.Equals("True"))
            {
                if (this.interstitial3.IsLoaded())
                {
                    this.interstitial3.Show();
                }
                else
                {
                    this.RequestInterstialAd3();
                }
            }
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    ///     ================================================================================================================================================================================================================
    public void ShowRewardedVideoAdAdmob1()//----------------------------------------------------------------------------------------reward-1----------------------------------------------------
    {
        if (showaads.Equals("True"))
        {
            if (showrewardedVideoAdsID1.Equals("True"))
            {
                if (rewardVideoAd1.IsLoaded())
                {
                    //Debug.Log("Rewarded was loaded succesfully!");

                    rewardVideoAd1.Show();
                }
                else
                {
                    // Debug.Log("inter" + args.LoadAdError.ToString());

                    this.RequestRewardedVideoAd1();
                }
            }
        }
    }
    //public void ShowRewardedVideoAdAdmob2()//----------------------------------------------------------------------------------------reward-2----------------------------------------------------
    //{
    //    if (rewardVideoAd2.IsLoaded())
    //    {
    //        //Debug.Log("Rewarded was loaded succesfully!");

    //        rewardVideoAd2.Show();
    //    }
    //}



    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       // this.InitializeAds();
       
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this.InitializeAds();
        this.RequestInterstialAd1();
        this.RequestInterstialAd2();
        this.RequestInterstialAd3();
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.RequestRewardedVideoAd1();
       // FindObjectOfType<gamemanager>().IncreaseNumberOfBalls();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        FindObjectOfType<gamemanager>().IncreaseNumberOfBalls();
        this.RequestRewardedVideoAd1();

    }

}
