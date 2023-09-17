using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;



public class SplashScript : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(getAdsData());
    }


    IEnumerator getAdsData()
    {
        WWWForm form = new WWWForm();
        //  form.AddField("app_key", "TEST");

        UnityWebRequest www = UnityWebRequest.Get("https://script.google.com/macros/s/AKfycbwYBwW4XzaYdPMdn7xCRU2U20jjzSIjk9i3SmfqYcU-Hs8hH3SkEVWMOGaQ-t8xY7bQ/exec?scriptId=1l7wXK_WRMV0eA3udaM7PBznWATsr9utn6rI4Z5bXMYE");


        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            //Invoke("Delay", 5.0f);
            byte[] result = www.downloadHandler.data;


            string responseData = System.Text.Encoding.Default.GetString(result);
            Debug.Log(responseData);

            JSONNode jsonNode = SimpleJSON.JSON.Parse(responseData);
            string successx = jsonNode["sucess"].Value;
            string playerx = jsonNode["adsData"][0]["app_key"].Value;


            AdsParameter.instance.app_key = jsonNode["adsData"][0]["app_key"].Value;

            AdsParameter.instance.g_app_id = jsonNode["adsData"][0]["g_app_id"].Value;
            AdsParameter.instance.g_banner1 = jsonNode["adsData"][0]["g_banner1"].Value;
            AdsParameter.instance.g_banner2 = jsonNode["adsData"][0]["g_banner2"].Value;
            AdsParameter.instance.g_banner3 = jsonNode["adsData"][0]["g_banner3"].Value;
            AdsParameter.instance.g_inter1 = jsonNode["adsData"][0]["g_inter1"].Value;
            AdsParameter.instance.g_inter2= jsonNode["adsData"][0]["g_inter2"].Value;
            AdsParameter.instance.g_inter3 = jsonNode["adsData"][0]["g_inter3"].Value;
            AdsParameter.instance.g_rewarded1 = jsonNode["adsData"][0]["g_rewarded1"].Value;
            AdsParameter.instance.g_rewarded2 = jsonNode["adsData"][0]["g_rewarded2"].Value;
            AdsParameter.instance.g_rewarded3 = jsonNode["adsData"][0]["g_rewarded3"].Value;
            AdsParameter.instance.showAds = jsonNode["adsData"][0]["showAds"].Value;
            AdsParameter.instance.show_g_banner1 = jsonNode["adsData"][0]["show_g_banner1"].Value;
            AdsParameter.instance.show_g_banner2 = jsonNode["adsData"][0]["show_g_banner2"].Value;
            AdsParameter.instance.show_g_banner3 = jsonNode["adsData"][0]["show_g_banner3"].Value;
            AdsParameter.instance.show_g_inter1 = jsonNode["adsData"][0]["show_g_inter1"].Value;
            AdsParameter.instance.show_g_inter2 = jsonNode["adsData"][0]["show_g_inter2"].Value;
            AdsParameter.instance.show_g_inter3 = jsonNode["adsData"][0]["show_g_inter3"].Value;
            AdsParameter.instance.show_g_native1 = jsonNode["adsData"][0]["show_g_native1"].Value;
            AdsParameter.instance.show_g_rewarded1 = jsonNode["adsData"][0]["show_g_rewarded1"].Value;
            AdsParameter.instance.show_g_rewarded2 = jsonNode["adsData"][0]["show_g_rewarded2"].Value;
            AdsParameter.instance.show_g_rewarded3 = jsonNode["adsData"][0]["show_g_rewarded3"].Value;
            AdsParameter.instance.show_loading = jsonNode["adsData"][0]["show_loading"].Value;
            AdsParameter.instance.extraStringPara1 = jsonNode["adsData"][0]["extraStringPara1"].Value;
            AdsParameter.instance.extraStringPara2 = jsonNode["adsData"][0]["extraStringPara2"].Value;
            AdsParameter.instance.ad_app_name = jsonNode["adsData"][0]["ad_app_name"].Value;
            AdsParameter.instance.ad_app_url = jsonNode["adsData"][0]["ad_app_url"].Value;
            AdsParameter.instance.ad_banner_url = jsonNode["adsData"][0]["ad_banner_url"].Value;
            AdsParameter.instance.ad_dialog_title = jsonNode["adsData"][0]["ad_dialog_title"].Value;
            AdsParameter.instance.ad_icon_url = jsonNode["adsData"][0]["ad_icon_url"].Value;
            AdsParameter.instance.ad_message = jsonNode["adsData"][0]["ad_message"].Value;
            AdsParameter.instance.isAds = jsonNode["adsData"][0]["isAds"].Value;
            AdsParameter.instance.isNotification = jsonNode["adsData"][0]["isNotification"].Value;
            AdsParameter.instance.isUpdate = jsonNode["adsData"][0]["isUpdate"].Value;
            AdsParameter.instance.not_dialog_title = jsonNode["adsData"][0]["not_dialog_title"].Value;
            AdsParameter.instance.not_message = jsonNode["adsData"][0]["not_message"].Value;
            AdsParameter.instance.not_show_dialog = jsonNode["adsData"][0]["not_show_dialog"].Value;
            AdsParameter.instance.update_app_url = jsonNode["adsData"][0]["update_app_url"].Value;
            AdsParameter.instance.update_dialog_title = jsonNode["adsData"][0]["update_dialog_title"].Value;
            AdsParameter.instance.update_message = jsonNode["adsData"][0]["update_message"].Value;
            AdsParameter.instance.update_show_cancel = jsonNode["adsData"][0]["update_show_cancel"].Value;
            AdsParameter.instance.update_title = jsonNode["adsData"][0]["update_title"].Value;
            AdsParameter.instance.update_version_name = jsonNode["adsData"][0]["update_version_name"].Value;

            //AdsParameter.instance.showAds = jsonNode["adsData"][0]["showAds"].Value;
            //AdsParameter.instance.show_g_banner1 = jsonNode["adsData"][0]["show_g_banner1"].Value;
            //AdsParameter.instance.show_g_inter1 = jsonNode["adsData"][0]["show_g_inter1"].Value;
            //AdsParameter.instance.show_g_inter2 = jsonNode["adsData"][0]["show_g_inter2"].Value;
            //AdsParameter.instance.show_g_inter3 = jsonNode["adsData"][0]["show_g_inter3"].Value;
            //AdsParameter.instance.show_g_rewarded1 = jsonNode["adsData"][0]["show_g_rewarded1"].Value;


            Debug.Log("success:" + successx);
            Debug.Log("data :" + playerx);




        }

    }

    //public void Delay()
    //{
    //    SceneManager.LoadScene("start");
    //}

}
