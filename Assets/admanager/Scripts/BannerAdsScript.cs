using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BannerAdsScript : MonoBehaviour
{
    private BannerView bannerView;

    private InterstitialAd interstitial;
     private string appId;
    private string bannerAdId ;
    private string showaads;
    private string showbannerID;

    public void OnGUI()
    {
        GUI.skin.label.fontSize = 60;
        Rect textOutputRect = new Rect(
          0.15f * Screen.width,
          0.25f * Screen.height,
          0.7f * Screen.width,
          0.3f * Screen.height);
        //GUI.Label(textOutputRect, "Adaptive Banner Example");
    }
    public void Start()
    {
        showaads = AdsParameter.instance.showAds;
        showbannerID = AdsParameter.instance.show_g_banner1;
        //appId = AdsParameter.instance.g_app_id;
        bannerAdId = AdsParameter.instance.g_banner1;
        //bannerAdId = "ca-app-pub-4905629984957668/4268942489";
        MobileAds.Initialize(initStatus => { });
        if (SceneManager.GetActiveScene().name == "menu")
            this.RequestBanner();



        //  this.RequestInterstitial();

        //  if (this.interstitial.IsLoaded()) {
        //        this.interstitial.Show();
        //  }

    }

    private void RequestBanner()
    {
        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        if (showaads.Equals("True"))
        {
            if (showbannerID.Equals("True"))
            {
                // string adUnitId = bannerAdId;

                AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

                this.bannerView = new BannerView(bannerAdId, adaptiveSize, AdPosition.Bottom);

                AdRequest request = new AdRequest.Builder().Build();

                this.bannerView.LoadAd(request);
            }
        }
    }

}
